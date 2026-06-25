package Frame;
import Class.*;
import java.lang.*;
import java.awt.*;
import javax.swing.*;
import java.awt.event.*;

public class aProfile extends JFrame implements MouseListener,ActionListener{
	JPanel panel;
	JLabel bg,nameLabel,passwordLabel,numberLabel,genderLabel,dobLabel,addressLabel,emailLabel;
	//JTextField searchField;
	JButton backButton,editButton,deleteButton;
	users us;
	books bs;
	admin a;
	admins as;
	
	public aProfile(users us,books bs,admin a,admins as){
		super("Customer profile");
		this.setSize(800,500);
		this.setResizable(false);
		this.setLocationRelativeTo(null);
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		this.us=us;
		this.bs=bs;
		this.a=a;
		this.as=as;
		
		panel=new JPanel();
		panel.setLayout(null);
		
		Font myFont = new Font("Cambria", Font.PLAIN, 17);
		
		nameLabel = new JLabel("User name: "+a.getName()); 
		nameLabel.setBounds(480,60,300,30);
		nameLabel.setFont(myFont);
		panel.add(nameLabel);
		
	
		passwordLabel = new JLabel("Password: "+a.getPassword());
		passwordLabel.setBounds(480,100,200,30);
		passwordLabel.setFont(myFont);
		panel.add(passwordLabel);
		
		numberLabel = new JLabel("Number: "+a.getNumber()); 
		numberLabel.setBounds(480,140,300,30);
		numberLabel.setFont(myFont);
		panel.add(numberLabel);
		
		emailLabel = new JLabel("Email: "+a.getEmail()); 
		emailLabel.setBounds(480,180,300,30);
		emailLabel.setFont(myFont);
		panel.add(emailLabel);
		
		
		genderLabel = new JLabel("Gender: "+a.getGender());
		genderLabel.setBounds(480,220,300,30);
		genderLabel.setFont(myFont);
		panel.add(genderLabel);
		
		dobLabel = new JLabel("Date of Birth: "+a.getDOB());
		dobLabel.setBounds(480,260,300,30);
		dobLabel.setFont(myFont);
		panel.add(dobLabel);
		
		addressLabel = new JLabel("Address: "+a.getAddress());// u
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
	}
	public void actionPerformed(ActionEvent ae){
	    String command = ae.getActionCommand();
		
		if(ae.getSource()== editButton){
			this.setVisible(false);
			aEditProfile cUn = new aEditProfile (us,bs,a,as);
			cUn.setVisible(true);
		}
		if(ae.getSource()==backButton){
			adminHome cm=new adminHome(us,bs,a,as);
			cm.setVisible(true);
			this.setVisible(false);
		}
	}
} 