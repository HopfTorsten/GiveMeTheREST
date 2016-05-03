package de.dhbw.give.me.the.model;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;
import javax.validation.constraints.NotNull;

@Entity
@Table(name = "GiveMeAMessage")
public class GiveMeAMessage {

	@Id @GeneratedValue
	@Column(name ="id")
	private Integer id;
	
	@Column(name = "parent")
	private Integer parent;
	
	@Column(name = "content")
	@NotNull
	private String content;
	
	public GiveMeAMessage(){
		
	}

	public GiveMeAMessage(Integer parent, String content) {
		super();
		this.parent = parent;
		this.content = content;
	}

	public Integer getId() {
		return id;
	}

	public void setId(Integer id) {
		this.id = id;
	}

	public Integer getParent() {
		return parent;
	}

	public void setParent(Integer parent) {
		this.parent = parent;
	}

	public String getContent() {
		return content;
	}

	public void setContent(String content) {
		this.content = content;
	}
	
}
