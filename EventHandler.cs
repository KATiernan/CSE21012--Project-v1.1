using System //makes the coding easier

public delegate void MyEventHandler(Object caller, MyEventArgs e);//delegating the event
public class MyEnventArgs: EventArgs{ //the EventArgs class
//constructors,fields and accessors to the arguements
}

public class EventsCalling{ //creating the events
	public event EventHandler A //declaring and event
	public event EventHandler B
	public event EventHandler C
	public event EventHandler D
	public event EventHandler E
	protected virtual void OnA(EventHandlerEventArgs e){ //OnEvent methods, can be used to send the events
		if(A != null)
		A(this, e);
	}
	protected virtual void OnB(EventHandlerEventArgs e){ //OnEvent methods, can be used to send the events
		if(B != null)
		B(this, e);
	}
	protected virtual void OnC(EventHandlerEventArgs e){ //OnEvent methods, can be used to send the events
		if(C != null)
		C(this, e);
	}
	protected virtual void OnD(EventHandlerEventArgs e){ //OnEvent methods, can be used to send the events
		if(D != null)
		D(this, e);
	}
	protected virtual void OnE(EventHandlerEventArgs e){ //OnEvent methods, can be used to send the events
		if(E != null)
		E(this, e);
	}
}

public class EventsPlaying{
	EventsCalling caller;
	public EventsPlayer(){
		caller = new EventsCalling();
	}
	caller.A += new MyEventHandler(this.caller_A); //to add the handler to an event
	caller.A -= new MyEventHandler(this.caller_A); //to remove the handler from an event
	private void caller_A(object caller, MyEventArgs e){
	}
	caller.B += new MyEventHandler(this.caller_B); //to add the handler to an event
	caller.B -= new MyEventHandler(this.caller_B); //to remove the handler from an event
	private void caller_B(object caller, MyEventArgs e){
	}
	caller.C += new MyEventHandler(this.caller_C); //to add the handler to an event
	caller.C -= new MyEventHandler(this.caller_C); //to remove the handler from an event
	private void caller_C(object caller, MyEventArgs e){
	}
	caller.D += new MyEventHandler(this.caller_D); //to add the handler to an event
	caller.D -= new MyEventHandler(this.caller_D); //to remove the handler from an event
	private void caller_D(object caller, MyEventArgs e){
	}
	caller.E += new MyEventHandler(this.caller_E); //to add the handler to an event
	caller.E -= new MyEventHandler(this.caller_E); //to remove the handler from an event
	private void caller_E(object caller, MyEventArgs e){
	}
}

//Think these are wrong but they might work:
//Instructions:
//import the EventsHandler
//instantiate the caller as a new EventsCalling()
//caller.A += new MyEventHandler(this.caller_A) starts the event
//write the above line to start the event
//caller.A -= new MyEventHandler(this.caller_A) ends the event
//write the above line to end the event

//This is from the source: https://www.codeproject.com/Articles/5043/Step-by-Step-Event-handling-in-C
//This source might help is explaining how to use the code: https://www.codeproject.com/articles/1474/events-and-event-handling-in-c
