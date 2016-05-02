/**
 * 
 */
package de.dhbw.give.me.the.REST;
import java.util.List;

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
	
	  // This method is called if HTML is request
	  @GET
	  @Produces(MediaType.TEXT_HTML)
	  public String sayHtmlHello() {
	    return "<html> " + "<title>" + "Hello Jersey" + "</title>"
	        + "<body><h1>" + "Hello Jersey" + "</body></h1>" + "</html> ";
	  }
	  
	  @GET
	  @Produces(MediaType.APPLICATION_JSON)
	  public List<GiveMeAMessage> giveRootMessages(){
		  return null;
	  }
	
}
