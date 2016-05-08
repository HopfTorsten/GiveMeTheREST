package de.dhbw.give.me.the.REST;

import java.util.Arrays;
import java.util.List;

import de.dhbw.give.me.the.model.GiveMeAMessage;

public class Messages{
	private final List<GiveMeAMessage> messages;
	
	public List<GiveMeAMessage> getMessages() {
		return messages;
	}

	public Messages(GiveMeAMessage ... msgs){
		messages = Arrays.asList(msgs);
	}
}