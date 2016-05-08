package de.dhbw.give.me.the.REST;

import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.QueryParam;
import javax.ws.rs.core.MediaType;

import de.dhbw.give.me.the.model.GiveMeAMessage;

@Path("/msg")
public class MessageService {
	
	@GET
	@Produces(MediaType.APPLICATION_JSON)
	public Messages getAllChildMessages(@QueryParam("id") Integer id){
		
		if(id == null){
			return createFakeMessages();
		}
		return createFakeMessages(id);
		
		
	}
	
	private Messages createFakeMessages(){
		GiveMeAMessage aRootMessage = new GiveMeAMessage(null, "Ich bin die root message");
		aRootMessage.setId(1);
		
		GiveMeAMessage aChildMessage = new GiveMeAMessage(1,"Ich bin die erste child Message");
		aChildMessage.setId(2);
		
		GiveMeAMessage anotherChildMessage = new GiveMeAMessage(1,"Ich bin die zweite child Message");
		aChildMessage.setId(3);
		
		GiveMeAMessage aChildChildMessage = new GiveMeAMessage(3,"Ich bin die erste Child message der zweiten Child Message");
		aChildMessage.setId(4);

		return new Messages(aRootMessage,aChildMessage,anotherChildMessage,aChildChildMessage);
	}
	
	private Messages createFakeMessages(Integer id){
		GiveMeAMessage aRootMessage = new GiveMeAMessage(id, "Ich bin die root message");
		aRootMessage.setId(id+1);
		
		GiveMeAMessage aChildMessage = new GiveMeAMessage(1,"Ich bin die erste child Message");
		aChildMessage.setId(id+2);
		
		GiveMeAMessage anotherChildMessage = new GiveMeAMessage(1,"Ich bin die zweite child Message");
		aChildMessage.setId(id+3);
		
		GiveMeAMessage aChildChildMessage = new GiveMeAMessage(3,"Ich bin die erste Child message der zweiten Child Message");
		aChildMessage.setId(id+4);

		return new Messages(aRootMessage,aChildMessage,anotherChildMessage,aChildChildMessage);
	}
}


