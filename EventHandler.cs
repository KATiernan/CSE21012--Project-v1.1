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
		caller = new EventsCaller();
	}
	caller.TheChange += new MyEventHandler(this.caller_TheChange);//to add the handler to an event
	caller.TheChange -= new MyEventHandler(this.caller_TheChange);//to remove the handler from an event
	private void caller_TheChange(object caller, MyEventArgs e){
	}
}

//This is from the source: https://www.codeproject.com/Articles/5043/Step-by-Step-Event-handling-in-C
