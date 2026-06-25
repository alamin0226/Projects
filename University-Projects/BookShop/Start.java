import java.lang.*;
//package Frames;
import Class.*;
//package Class;

import Frame.*;
public class Start{
	public static void main(String[] args){
		admins as=new admins();
		books bs=new books();
		users us=new users();
		user u=us.getUser(1);
		admin a=as.getUser(1);
		
		intro in=new intro(us,bs,as);
		in.setVisible(true);
		
		
	}
}