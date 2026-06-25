package Class;
import java.lang.*;

public class admin{
	private String name;
	private String password;
	private String number;
	private String email;
	private String gender;
	private String dob;
	private String address;
	
	public admin(){}
	public admin(String name, String password,String number,String email, String gender,String dob,String address){
		this.name = name;
		this.password = password;
		this.email=email;
		this.number=number;
		this.gender = gender;
		this.dob = dob;
		this.address = address;
	}
	
	public void setName(String name){
		this.name = name;
	}
	public void setPassword(String password){
		this.password = password;
	}
	public void setNumber(String number){
		this.number=number;
	}
	public void setEmail(String email){
		this.email=email;
	}
	public void setGender(String gender){
		this.gender = gender;
	}
	public void setDOB(String dob){
		this.dob = dob;
	}
	public void setAddress(String address){
		this.address = address;
	}
	
	public String getName(){
		return name;
	}
	public String getPassword(){
		return password;
	}
	public String getNumber(){
		return number;
	}
	public String getEmail(){
		return email;
	}
	public String getGender(){
		return gender;
	}
	public String getDOB(){
		return dob;
	}
	public String getAddress(){
		return address;
	}
}