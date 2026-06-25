package Class;
import java.lang.*;

public class book{
	private String name;
	private String ISBN;
	private String price;
	private String quantity;
	
	public book(){}
	public book(String name, String ISBN,String price,String quantity){
		this.name = name;
		this.ISBN = ISBN;
		this.price=price;
		this.quantity=quantity;
	}
	
	public void setName(String name){
		this.name = name;
	}
	public void setISBN(String ISBN){
		this.ISBN = ISBN;
	}
	public void setPrice(String price){
		this.price=price;
	}
	public void setQuantity(String quantity){
		this.quantity=quantity;
	}
	
	public String getName(){
		return name;
	}
	public String getISBN(){
		return ISBN;
	}
	public String getPrice(){
		return price;
	}
	public String getQuantity(){
		return quantity;
	}
}