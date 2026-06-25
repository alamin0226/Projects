package Class;
import java.lang.*;
import java.io.*;
import java.util.Scanner;

public class admins{
	admin adminList[] = new admin[200];
	static int userCount = 0;
	
	public admins(){
		//reading the file and creating user objects to add them to the adminList array
		try{
			File file = new File("Files/adminList.txt"); //location must be the path where the file is saved
			Scanner sc = new Scanner(file);
				while(sc.hasNext()){
					String line1 = sc.nextLine();  //name
					String line2 = sc.nextLine();  //password
					String line3 = sc.nextLine();  //number
					String line4 = sc.nextLine();  //email
					String line5 = sc.nextLine();  //gender
					String line6 = sc.nextLine();  //date of birth
					String line7 = sc.nextLine();  //address
					String line8 = sc.nextLine();  //extra newline for space between two objects
					
					//printing them to cmd just to see if they are getting added to the list or not
				 	System.out.println(line1);
					System.out.println(line2);
					System.out.println(line3);
					System.out.println(line4);
					System.out.println(line5);
					
					//user u = new user("sadia","1234","Female","1/JAN/1990","Mirpur");
					admin u = new admin(line1,line2,line3,line4,line5,line6,line7);
					adminList[userCount] = u; 
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
	
	public int userExists(String name){
		int index = -1; //setting index value -1
		for(int i=0;i<userCount;i++){
			if(adminList[i].getName().equals(name)){
				index = i; //if any user exists with this name then, he/she must in one of the indexes of adminList array
				break;
			}
		}
		return index; //if user exists then the index that the user is in, that index will be returned
		              //otherwise -1 will be returned
	}
	
	public admin checkCredentials(int index, String pass){
		if((adminList[index].getPassword().equals(pass))){
			return adminList[index]; //if the user exists, we will check the password, if matches return the user object which resides in userList array in given index
		}else{return null;}         //otherwise return null, meaning password incorrect
	}
	
	public admin getUser(int index){
		return adminList[index];
	}
	
	public void addUser(admin u){
		//adding the user to the adminList array
		adminList[userCount] = u;
		userCount++;
		
		//also adding them in file
		String userDetails=u.getName() + "\n" + u.getPassword() + "\n" + u.getNumber() + "\n" + u.getEmail() + "\n" +
						   u.getGender() + "\n"+ u.getDOB() + "\n" +
						   u.getAddress() + "\n" + "\n";
		try{
			FileWriter fw = new FileWriter("Files/adminList.txt",true);
			fw.write(userDetails);
			fw.close();
		}catch(Exception ex){
			System.out.println(ex);
		}
	}
	
	public void deleteUser(String name){
		//deleting them from array
		admin u = null;
		for(int i = 0; i<userCount; i++){
			if(adminList[i].getName().equals(name)){
				u = adminList[i];
				for(int j = i; j< userCount; j++){
					adminList[j] = adminList[j+1];
				}
				userCount--;
				adminList[userCount] = null;
				break;
			}
		}
		
		//also deleting from file
		String userDetails=u.getName() + "\n" + u.getPassword() + "\n" + u.getNumber() + "\n" + u.getEmail() + "\n"+ 
						   u.getGender() + "\n"+ u.getDOB() + "\n" +
						   u.getAddress() + "\n";
		
		try{
			String filepath = "Files/adminList.txt";
			File originalFile = new File(filepath);
				
			String newDetails = "";				
			Scanner sc = new Scanner(originalFile);
			while(sc.hasNext()){
				String readUser = sc.nextLine() + "\n";
					   readUser += sc.nextLine() + "\n";
				       readUser += sc.nextLine() + "\n";
				       readUser += sc.nextLine() + "\n";
					   readUser += sc.nextLine() + "\n";
					   readUser += sc.nextLine() + "\n";
				       readUser += sc.nextLine() +"\n";
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
	
	public void updateUser(admin oldUser, admin updatedUser){
		String oldUserDetails = oldUser.getName() + "\n" + 
								oldUser.getPassword() + "\n"+
								oldUser.getNumber() + "\n"+
								oldUser.getEmail() + "\n"+
								oldUser.getGender() + "\n"+ 
								oldUser.getDOB() + "\n" +
								oldUser.getAddress() + "\n";
								
		String updatedDetails = updatedUser.getName() + "\n" + 
								updatedUser.getPassword() + "\n"+
								updatedUser.getNumber() + "\n"+
								updatedUser.getEmail() + "\n"+
								updatedUser.getGender() + "\n"+ 
								updatedUser.getDOB() + "\n" +
								updatedUser.getAddress() + "\n";
		//updating in file
		try{
			String filepath = "Files/adminList.txt";
			File originalFile = new File(filepath);
			
			String newDetails = "";				
			Scanner sc = new Scanner(originalFile);
			while(sc.hasNext()){
				String readUser = sc.nextLine() + "\n";
				readUser += sc.nextLine() + "\n";
				readUser += sc.nextLine() + "\n";
				readUser += sc.nextLine() + "\n";
				readUser += sc.nextLine() + "\n";
				readUser += sc.nextLine() + "\n";
				readUser += sc.nextLine() +"\n";
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