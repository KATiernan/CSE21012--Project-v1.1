using System //makes the coding easier

public delegate void MyEventHandler(Object caller, MyEventArgs e);//delegating the event
public class MyEnventArgs: EventArgs{ //the EventArgs class
//constructors,fields and accessors to the arguements
}

public class EventsCalling{ //creating the events
	public event EventHandler TheChange//declaring and event
	protected virtual void OnTheChange(EventHandlerEventArgs e){//OnEvent methods, can be used to send the events
		if(TheChange != null)
		TheChange(this, e);
	}
}

public class EventsPlaying{
	EventsCalling caller;
	public EventsPlayer(){
		caller = new EventsCalling();
	}
	caller.TheChange += new MyEventHandler(this.caller_TheChange);//to add the handler to an event
	caller.TheChange -= new MyEventHandler(this.caller_TheChange);//to remove the handler from an event
	private void caller_TheChange(object caller, MyEventArgs e){
	}
}

//Instructions:
//import the EventsHandler
//instantiate the caller as a new EventsCalling()
//caller.TheChange += new MyEventHandler(this.caller_TheChange) starts the event
//write the above line to start the event
//caller.TheChange -= new MyEventHandler(this.caller_TheChange) ends the event
//write the above line to end the event

//This is from the source: https://www.codeproject.com/Articles/5043/Step-by-Step-Event-handling-in-C
//This source might help is explaining how to use the code: https://www.codeproject.com/articles/1474/events-and-event-handling-in-c
