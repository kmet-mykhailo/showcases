import { Observable, Observer } from 'rxjs';

// --- 1. Basic Observable ---
const letters$: Observable<string> = new Observable<string>((subscriber)=>{
    subscriber.next('a');
    subscriber.next('b');
    subscriber.next('c');
    subscriber.complete();
    subscriber.next('d'); // Is not delivered because it would violate the contract
});

// creqate an observer
const observer: Observer<string> = {
    next: val => console.log('Letter:', val),
    error: error => console.log('Error:', error),
    complete: () => console.log('Completed!')
};

console.log('== Before subscribe() ==');
letters$.subscribe(observer);
console.log('== After subscribe() ==');

// another subscribe
console.log();
console.log('== Before second subscribe() ==');
letters$.subscribe(val => console.log('Letter:', val));
console.log('== After second subscribe() ==');