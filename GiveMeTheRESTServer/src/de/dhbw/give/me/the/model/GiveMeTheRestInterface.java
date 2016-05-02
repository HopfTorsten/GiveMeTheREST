package de.dhbw.give.me.the.model;
import java.util.List;
public interface GiveMeTheRestInterface {

	public List<GiveMeAMessage> getRootMessages();
	
	public List<GiveMeAMessage> getAllMessages();
	
	public List<GiveMeAMessage> getChildMessages(Integer parent);
	
	public List<GiveMeAMessage> getRootChildMessages(Integer parent);
	
	public Integer addNewMessage(GiveMeAMessage message);
	
	
}
