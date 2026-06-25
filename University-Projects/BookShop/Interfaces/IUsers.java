package Interfaces;
import Class.*;
public interface IUsers{
	void addUser(user u);
	user getUser(int index);
	void deleteUser(String name);
	void updateUser(user oldUser, user updatedUser);
}