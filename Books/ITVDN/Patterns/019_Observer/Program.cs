using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _019_Observer
{
    // Паттерн для реализации событийной модели
    abstract class Subject
    {
        ArrayList observers = new ArrayList();
        public void Attach(Observer observer)
        {
            observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            observers.Remove(observer);
        }
        public void Notify()
        {
            foreach (Observer observer in observers)
            {
                observer.Update();
            }
        }
    }
    public abstract class Observer
    {
        public abstract void Update();
    }

    class ConcreteSubject : Subject
    {
        public string State { get; set; }
    }

    class ConcreteObserver : Observer
    {
        string observerState;
        ConcreteSubject subject;

        public ConcreteObserver(ConcreteSubject subject)
        {
            this.subject = subject;
        }

        public override void Update()
        {
            observerState = subject.State;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var subject = new ConcreteSubject();
            subject.Attach(new ConcreteObserver(subject));
            subject.Attach(new ConcreteObserver(subject));
            subject.State = "Some state";
            subject.Notify();
            Console.ReadKey();
        }
    }
}
