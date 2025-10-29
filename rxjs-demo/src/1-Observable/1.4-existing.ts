import { Observable, of, from, interval } from 'rxjs';

// of - Emits the arguments you pass in sequence.
const letters$: Observable<string> = of('a','b','c');

console.log('== Before of subscribe() ==');
letters$.subscribe(val => console.log('Letter:', val));
console.log('== After of subscribe() ==');

// from - Converts an array, promise, or iterable into an observable.
const anotherLetters$: Observable<string> = from(['d','e','f']);

console.log();
console.log('== Before from subscribe() ==');
anotherLetters$.subscribe(val => console.log('Letter:', val));
console.log('== After from subscribe() ==');

// interval - Emits sequential numbers every specified interval.
const numbers$: Observable<number> = interval(2000);

console.log();
console.log('== Before interval subscribe() ==');
numbers$.subscribe(val => console.log('Number:', val));
console.log('== After interval subscribe() ==');
