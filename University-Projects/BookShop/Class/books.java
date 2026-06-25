package Class;
import java.lang.*;
import java.io.*;
import java.util.Scanner;

public class books{
	book bookList[] = new book[200];
	static int userCount = 0;
	
	public books(){
		//reading the file and creating book objects to add them to the userList array
		try{
			File file = new File("Files/bookList.txt"); //location must be the path where the file is saved
			Scanner sc = new Scanner(file);
				while(sc.hasNext()){
					String line1 = sc.nextLine();  //name
					String line2 = sc.nextLine();  //password
					String line3 = sc.nextLine();  //number
					String line4 = sc.nextLine();  //email
					String line5 = sc.nextLine();  //gender
				
					//printing them to cmd just to see if they are getting added to the list or not
				 	System.out.println(line1);
					System.out.println(line2);
					System.out.println(line3);
					System.out.println(line4);
					System.out.println(line5);
					
					//user u = new user("sadia","1234","Female","1/JAN/1990","Mirpur");
					book u = new book(line1,line2,line3,line4);
					bookList[userCount] = u; 
					userCount++;
					System.out.println(userCount+"////////////////////////////");
				}
			sc.close();   //closing the file 		
		}catch(Exception ex){
			System.out.println(ex);
			System.out.println("File not found.");
			return;
		}
	}
	
	public int userExists(String ISBN){
		int index = -1; //setting index value -1
		for(int i=0;i<userCount;i++){
			if(bookList[i].getISBN().equals(ISBN)){
				index = i; //if any user exists with this name then, he/she must in one of the indexes of userList array
				break;
			}
		}
		return index; //if user exists then the index that the user is in, that index will be returned
		              //otherwise -1 will be returned
	}
	
	public book checkCredentials(int index, String ISBN){
		if((bookList[index].getISBN().equals(ISBN))){
			return bookList[index]; //if the user exists, we will check the password, if matches return the user object which resides in userList array in given index
		}else{return null;}         //otherwise return null, meaning password incorrect
	}
	
	public book getUser(int index){
		return bookList[index];
	}
	
	public void addUser(book u){
		//adding the user to the userList array
		bookList[userCount] = u;
		userCount++;
		
		//also adding them in file
		String userDetails=u.getName() + "\n" + u.getISBN() + "\n" + u.getPrice() + "\n" + u.getQuantity() + "\n" +
			
						 "\n";
		try{
			FileWriter fw = new FileWriter("Files/bookList.txt",true);
			fw.write(userDetails);
			fw.close();
		}catch(Exception ex){
			System.out.println(ex);
		}
	}
	
	public void deleteUser(String ISBN){
		//deleting them from array
		book u = null;
		for(int i = 0; i<userCount; i++){
			if(bookList[i].getISBN().equals(ISBN)){
				u = bookList[i];
				for(int j = i; j< userCount; j++){
					bookList[j] = bookList[j+1];
				}
				userCount--;
				bookList[userCount] = null;
				break;
			}
		}
		
		//also deleting from file
		String userDetails=u.getName() + "\n" + u.getISBN() + "\n" + u.getPrice() + "\n" + u.getQuantity() + "\n"; 
					
						  // u.getAddress() + "\n";
		
		try{
			String filepath = "Files/bookList.txt";
			File originalFile = new File(filepath);
				
			String newDetails = "";				
			Scanner sc = new Scanner(originalFile);
			while(sc.hasNext()){
				String readUser = sc.nextLine() + "\n";
					   readUser += sc.nextLine() + "\n";
				       readUser += sc.nextLine() + "\n";
				       readUser += sc.nextLine() + "\n";
				       readUser += sc.nextLine();
				
				System.out.println(readUser);
				System.out.println(userDetails);
				
				if(readUser.equals(userDetails)){
					System.out.println("Equal, so deleting");
					continue;
				}
				System.out.println("Writing");
				newDetails += readUser + "\n";
			} sc.close(); 
			FileWriter fw = new FileWriter(filepath);
			fw.write(newDetails);
			fw.close();
		}catch(Exception ex){
			System.out.println(ex);
		}
	}
	
	public void updateUser(book oldUser, book updatedUser){
		String oldUserDetails = oldUser.getName() + "\n" + 
								oldUser.getISBN() + "\n"+
								oldUser.getPrice() + "\n"+
								oldUser.getQuantity() + "\n";
								
		String updatedDetails = updatedUser.getName() + "\n" + 
								updatedUser.getISBN() + "\n"+
								updatedUser.getPrice() + "\n"+
								updatedUser.getQuantity() + "\n";
		//updating in file
		try{
			String filepath = "Files/bookList.txt";
			File originalFile = new File(filepath);
			
			String newDetails = "";				
			Scanner sc = new Scanner(originalFile);
			while(sc.hasNext()){
				String readUser = sc.nextLine() + "\n";
				readUser += sc.nextLine() + "\n";
				readUser += sc.nextLine() + "\n";
				readUser += sc.nextLine() + "\n";
				readUser += sc.nextLine();
				
				System.out.println(readUser);
				System.out.println(oldUserDetails);
				
				if(readUser.equals(oldUserDetails)){
					System.out.println("Updated");
					newDetails += updatedDetails + "\n";
				}else{
					System.out.println("Writing");
					newDetails += readUser + "\n";
				}
			} sc.close(); 
			FileWriter fw = new FileWriter(filepath);
			fw.write(newDetails);
			fw.close();
		}catch(Exception ex){
			System.out.println(ex);
		}
	}
}