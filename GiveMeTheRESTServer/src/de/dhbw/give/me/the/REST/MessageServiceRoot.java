/**
 * 
 */
package de.dhbw.give.me.the.REST;

import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

import de.dhbw.give.me.the.model.GiveMeAMessage;

/**
 * @author torsten.hopf
 *
 */
@Path("/msg/root")
public class MessageServiceRoot {


	@GET
	@Produces(MediaType.APPLICATION_JSON)
	public Messages getRootMessages(){
		GiveMeAMessage parentMessage = new GiveMeAMessage(null,
				"Ich bin die Parent message");
		parentMessage.setId(1);
		
		GiveMeAMessage parentMessage2 = new GiveMeAMessage(null,
				"Ich bin die zweite Parent message");
		parentMessage2.setId(2);
		
		Messages toReturn = new Messages(parentMessage,parentMessage2);
		return toReturn;
	}
	
	
}
