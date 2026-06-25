package Frame;
import Class.*;
import java.lang.*;
import java.awt.*;
import javax.swing.*;
import java.awt.event.*;

public class cProfile extends JFrame implements MouseListener,ActionListener{
	JPanel panel;
	JLabel bg,nameLabel,passwordLabel,numberLabel,genderLabel,dobLabel,addressLabel,emailLabel;
	//JTextField searchField;
	JButton backButton,editButton,deleteButton;
	users us;
	user u;
	books bs;
	admins as;
	public cProfile(user u,users us,books bs,admins as){
		super("Customer profile");
		this.setSize(800,500);
		this.setResizable(false);
		this.setLocationRelativeTo(null);
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		this.u=u;
		this.us=us;
		this.bs=bs;
		this.as=as;
		
		panel=new JPanel();
		panel.setLayout(null);
		
		Font myFont = new Font("Cambria", Font.PLAIN, 17);
		
		nameLabel = new JLabel("User name: "+u.getName()); 
		nameLabel.setBounds(480,60,300,30);
		nameLabel.setFont(myFont);
		panel.add(nameLabel);
		
		/*pass = u.getPassword();
		int passLenghth = pass.length();
		for(int i =0;i<passLenghth;i++){
			hiddenPass += '*';
		}*/
		passwordLabel = new JLabel("Password: "+u.getPassword());
		passwordLabel.setBounds(480,100,200,30);
		passwordLabel.setFont(myFont);
		panel.add(passwordLabel);
		
		numberLabel = new JLabel("Number: "+u.getNumber()); 
		numberLabel.setBounds(480,140,300,30);
		numberLabel.setFont(myFont);
		panel.add(numberLabel);
		
		emailLabel = new JLabel("Email: "+u.getEmail()); 
		emailLabel.setBounds(480,180,300,30);
		emailLabel.setFont(myFont);
		panel.add(emailLabel);
		
		
		genderLabel = new JLabel("Gender: "+u.getGender());
		genderLabel.setBounds(480,220,300,30);
		genderLabel.setFont(myFont);
		panel.add(genderLabel);
		
		dobLabel = new JLabel("Date of Birth: "+u.getDOB());
		dobLabel.setBounds(480,260,300,30);
		dobLabel.setFont(myFont);
		panel.add(dobLabel);
		
		addressLabel = new JLabel("Address: "+u.getAddress());
		addressLabel.setBounds(480,300,300,30);
		addressLabel.setFont(myFont);
		panel.add(addressLabel);
		
		
		editButton=new JButton("Edit profile");
		editButton.setBounds(480,350,100,30);
		//editButton.setBackground(new Color(133,70,255));
		editButton.addMouseListener(this);
		editButton.addActionListener(this);
		editButton.setBorder(null);
		panel.add(editButton);
		
		backButton=new JButton("Home");
		backButton.setBounds(630,350,100,30);
		//backButton.setBackground(new Color(133,70,255));
		backButton.addMouseListener(this);
		backButton.addActionListener(this);
		backButton.setBorder(null);
		panel.add(backButton);
		
		deleteButton=new JButton("Delete");
		deleteButton.setBounds(560,390,100,30);
		//deleteButton.setBackground(new Color(133,70,255));
		deleteButton.addMouseListener(this);
		deleteButton.addActionListener(this);
		deleteButton.setBorder(null);
		panel.add(deleteButton);
		
		ImageIcon img=new ImageIcon("Image/profile.jpg");
		Image i1=img.getImage().getScaledInstance(800,500,Image.SCALE_SMOOTH);
		ImageIcon i2=new ImageIcon(i1);
		
		bg=new JLabel(i2);
		bg.setSize(800,500);
		panel.add(bg);
		
		this.add(panel);
	}
	
	public void mouseClicked(MouseEvent me){}
	public void mousePressed(MouseEvent me){}
	public void mouseReleased(MouseEvent me){}

	public void mouseEntered(MouseEvent me){
		if(me.getSource()==editButton){
			editButton.setBackground(new Color(199,199,199));
			editButton.setForeground(Color.BLACK);
		}
		if(me.getSource()==backButton){
			backButton.setBackground(new Color(199,199,199));
			backButton.setForeground(Color.BLACK);
		}
		if(me.getSource()==deleteButton){
			deleteButton.setBackground(new Color(199,199,199));
			deleteButton.setForeground(Color.BLACK);
		}
	}
	public void mouseExited(MouseEvent me){
		if(me.getSource()== editButton){
			editButton.setBackground(new Color(255,255,255));
			editButton.setForeground(Color.BLACK);
		}
		if(me.getSource()==backButton){
			backButton.setBackground(new Color(255,255,255));
			backButton.setForeground(Color.BLACK);
		}
		if(me.getSource()==deleteButton){
			deleteButton.setBackground(new Color(255,255,255));
			deleteButton.setForeground(Color.BLACK);
		}
	}
	public void actionPerformed(ActionEvent ae){
	    String command = ae.getActionCommand();
		if(deleteButton.getText().equals(command)){
			int dialog = JOptionPane.YES_NO_OPTION;
			int result = JOptionPane.showConfirmDialog(this, "Are you sure you want to delete your profile?", "Delete user?", dialog);
			
			if(result == 0){
				us.deleteUser(u.getName());
				
				JOptionPane.showMessageDialog(this, "User deleted. Redirecting to login page.");
				
				customerSignin lg = new customerSignin(us,bs,as);
				lg.setVisible(true);
				this.setVisible(false);
			}else{ 
				//no nothing 
			}
		}
		if(ae.getSource()== editButton){
			dispose();
			cEditProfile cUn = new cEditProfile (u,us,bs,as);
			cUn.setVisible(true);
		}
		if(ae.getSource()==backButton){
			dispose();
			customerHome cm=new customerHome(u,us,bs,as);
			cm.setVisible(true);
		}
	}
}