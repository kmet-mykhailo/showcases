import { Observable, Observer, Subscription } from 'rxjs';

const letters$: Observable<string> = new Observable<string>((subscriber)=>{
    subscriber.next('a');
    subscriber.next('b');
    subscriber.next('c');
    setTimeout(() => {
        subscriber.next('d'); // happens asynchronously
        subscriber.complete();
      }, 1000);
});

const observer: Observer<string> = {
    next: val => console.log('Letter:', val, '(first)'),
    error: error => console.log('Error:', error, '(first)'),
    complete: () => console.log('Completed! (first)')
};

console.log('== Before first subscribe() ==');
letters$.subscribe(observer);
console.log('== After first subscribe() ==');

// another subscribe
console.log();
console.log('== Before second subscribe() ==');
let subscription: Subscription = letters$.subscribe(val => console.log('Letter:', val, '(second)'));
console.log('== After second subscribe() ==');

subscription.unsubscribe();
console.log('== Second subscribtion was unsubscribed ==');
console.log();