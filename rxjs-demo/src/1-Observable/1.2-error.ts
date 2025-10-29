import { Observable, Observer } from 'rxjs';

const letters$: Observable<string> = new Observable<string>((subscriber)=>{
    try {
        subscriber.next('a');
        subscriber.next('b');
        subscriber.next('c');
        throw "Error 1";
    } catch (err) {
        subscriber.error(err); // delivers an error if it caught one
        subscriber.next('d'); // Is not delivered because it would violate the contract
        subscriber.complete();
      }
});

const observer: Observer<string> = {
    next: val => console.log('Letter:', val),
    error: error => console.log('Error:', error),
    complete: () => console.log('Completed!')
};

console.log('== Before subscribe() ==');
letters$.subscribe(observer);
console.log('== After subscribe() ==');