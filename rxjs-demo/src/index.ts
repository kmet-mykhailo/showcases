import { of, from, interval, fromEvent, Subject, merge, Observable, Observer } from 'rxjs';
import { map, filter, take, debounceTime, switchMap, tap } from 'rxjs/operators';


// --- 1. Basic Observable ---
const numbers$: Observable<number> = of(1, 2, 3, 4, 5, 6);
const letters$: Observable<string> = new Observable<string>((subscriber)=>{
    subscriber.next('a');
    subscriber.next('b');
    subscriber.next('c');
    subscriber.complete();
});

numbers$.pipe(
  map(x => x * 2),
  filter(x => x >= 5)
).subscribe({
  next: val => console.log('Basic:', val),
  complete: () => console.log('Basic done')
});

const observer: Observer<string> = {
    next: val => console.log('Letter', val),
    error: error => console.log('error', error),
    complete: () => console.log('Letters done')
};
letters$.subscribe(observer);

// --- 2. Async stream simulation ---
const apiCall = (query: string) => from(
  new Promise<string>(res => setTimeout(() => res(`Results for "${query}"`), 1000))
);

const searchInput$ = new Subject<string>();

searchInput$.pipe(
  debounceTime(300),
  switchMap(query => apiCall(query))
).subscribe({
  next: val => console.log(val),
  error: err => console.error(err)
});

// simulate typing
searchInput$.next('a');
searchInput$.next('ap');
searchInput$.next('app');

// --- 3. Combine streams ---
const timer1$ = interval(1000).pipe(take(3));
const timer2$ = interval(500).pipe(take(3));

merge(timer1$, timer2$).subscribe({
  next: val => console.log('Merged stream value:', val),
  complete: () => console.log('Merged complete')
});
