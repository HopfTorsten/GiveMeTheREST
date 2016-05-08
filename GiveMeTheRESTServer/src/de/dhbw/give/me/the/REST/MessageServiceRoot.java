/**
 * 
 */
package de.dhbw.give.me.the.REST;

import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.QueryParam;
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
	public Messages getRootMessages(@QueryParam("id") Integer id){
		return getFakeMessages(id);
	}
	
	private Messages getFakeMessages(Integer id){
		GiveMeAMessage parentMessage = new GiveMeAMessage(id,
				"Ich bin die Parent message");
		parentMessage.setId((id == null)? 1 : id+1);
		
		GiveMeAMessage parentMessage2 = new GiveMeAMessage(id,
				"Ich bin die zweite Parent message");
		parentMessage2.setId((id == null)? 2 : id+2);
		
		Messages toReturn = new Messages(parentMessage,parentMessage2);
		return toReturn;
	}
	
}
