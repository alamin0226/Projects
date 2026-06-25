package Frame;
import Class.*;
import java.lang.*;
import java.awt.*;
import javax.swing.*;
import java.awt.event.*;
public class cEditProfile extends JFrame implements MouseListener,ActionListener{
	JPanel panel;
    JLabel bg1,patientName,patientPassword,conformPatientPassword,patientMobileNumber,emailLabel,genderLabel,addressLabel,dobLabel;
    JTextField nameField,numberField,emailField,addressField;
    JPasswordField passwordField,conformPasswordField;
	JButton signinButton,backButton;
	JRadioButton male,female,other;
	ButtonGroup bg;
	JComboBox date,month,year;
	users us;
	user u;
	books bs;
	admins as;

    public cEditProfile(user u,users us,books bs,admins as){
		super("Edit profile");
		this.setSize(800,500);
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		this.setLocationRelativeTo(null);
		this.setResizable(false);
		this.u=u;
		this.us=us;
		this.bs=bs;
		this.as=as;

        panel=new JPanel();
        panel.setLayout(null);
		panel.setBackground(new Color(176,36,160));
		
		Color ccl = new Color(195,215,235);
		Font f1=new Font("Arial",Font.BOLD,15);
		Font f2=new Font("Arial",Font.PLAIN,17);

        patientName=new JLabel("Username :");
        patientName.setBounds(295,90,100,20);
        //patientName.setOpaque(true);
		patientName.setFont(f1);
        panel.add(patientName);
        
        patientPassword=new JLabel("Password :");
        patientPassword.setBounds(295,130,100,20);
		patientPassword.setFont(f1);
        //patientPassword.setOpaque(true);
        panel.add(patientPassword);
		
		/*conformPatientPassword=new JLabel("Conform password :");
		conformPatientPassword.setBounds(295,130,200,20);
		conformPatientPassword.setFont(f1);
		panel.add(conformPatientPassword);*/
		
		patientMobileNumber=new JLabel("Phone number :");
		patientMobileNumber.setBounds(295,170,150,20);
		patientMobileNumber.setFont(f1);
		panel.add(patientMobileNumber);
		
		emailLabel=new JLabel("Enter your email account:");
		emailLabel.setBounds(295,210,200,20);
		emailLabel.setFont(f1);
		panel.add(emailLabel);
		
		genderLabel=new JLabel("Select gender :");
		genderLabel.setBounds(295,250,150,20);
		genderLabel.setFont(f1);
		panel.add(genderLabel);
		
		dobLabel = new JLabel("Date of Birth:");
		dobLabel.setBounds(295,290,150,20);
		dobLabel.setFont(f1);
		panel.add(dobLabel);
		
		String dates[]= {"1","2","3","4","5","6","7","8","9",
						"10","11","12","13","14","15","16","17",
						"18","19","20","21","22","23","24","25",
						"26","27","28","29","30","31"};
		date = new JComboBox(dates);
		date.setBackground(new Color(193,255,200));
		date.setBorder(null);
		date.setBounds(500,290,60,25);
		panel.add(date);
		
		String months[]= {"JAN","FEB","MAR","APR","MAY","JUN","JUL","AUG", "SEP","OCT","NOV","DEC"};
		month = new JComboBox(months);
		month.setBackground(new Color(193,255,200));
		month.setBorder(null);
		month.setBounds(570,290,60,25);
		panel.add(month);
		
		String years[]= {"1990","1991","1992","1993","1994",
		                 "1995","1996","1997","1998","1999","2000",
						 "2001","2002","2003","2004","2005","2006",
						 "2007","2008","2009","2010","2011","2012",
						 "2013","2014","2015","2016","2017","2018",
						 "2019","2020","2021","2022","2023","2024"};
		year = new JComboBox(years);
		year.setBackground(new Color(193,255,200));
		year.setBorder(null);
		year.setBounds(640,290,60,25);
		panel.add(year);
		
		addressLabel=new JLabel("Address :");
		addressLabel.setBounds(295,330,100,20);
		addressLabel.setFont(f1);
		panel.add(addressLabel);

        nameField=new JTextField(u.getName());
        nameField.setBounds(500,90,200,25);
		nameField.setBackground(new Color(193,255,200));
		nameField.setFont(f2);
		nameField.setBorder(null);
        panel.add(nameField);

        passwordField=new JPasswordField(u.getPassword());
        passwordField.setBounds(500,130,200,25);
		passwordField.setBackground(new Color(193,255,200));
		passwordField.setFont(f2);
		passwordField.setBorder(null);
		passwordField.setEchoChar('*');
        panel.add(passwordField);
		
	/*	conformPasswordField=new JPasswordField();
		conformPasswordField.setBounds(500,130,200,25);
		conformPasswordField.setFont(f2);
		conformPasswordField.setBorder(null);
		conformPasswordField.setBackground(new Color(193,255,200));
		panel.add(conformPasswordField);*/
		
		numberField=new JTextField(u.getNumber());
		numberField.setBounds(500,170,200,25);
		numberField.setFont(f2);
		numberField.setBorder(null);
		numberField.setBackground(new Color(193,255,200));
		panel.add(numberField);
		
		emailField=new JTextField(u.getEmail());
		emailField.setBounds(500,210,200,25);
		emailField.setFont(f2);
		emailField.setBorder(null);
		emailField.setBackground(new Color(193,255,200));
		panel.add(emailField);
		
		male=new JRadioButton("Male");
		male.setBounds(500,250,60,25);
		male.setBorder(null);
		male.setBackground(new Color(193,255,200));
		panel.add(male);
		
		female=new JRadioButton("Female");
		female.setBounds(570,250,60,25);
		female.setBorder(null);
		female.setBackground(new Color(193,255,200));
		panel.add(female);
		
		other=new JRadioButton("Other");
		other.setBounds(640,250,60,25);
		other.setBorder(null);
		other.setBackground(new Color(193,255,200));
		panel.add(other);
		
		bg=new ButtonGroup();
		bg.add(male);
		bg.add(female);
		bg.add(other);
		
		addressField=new JTextField(u.getAddress());
		addressField.setBounds(500,330,200,25);
		addressField.setFont(f2);
		addressField.setBorder(null);
		addressField.setBackground(new Color(193,255,200));
		panel.add(addressField);
		
		signinButton=new JButton("Save");
		signinButton.setBounds(500,375,80,30);
		signinButton.setBackground(new Color(193,255,200));
		signinButton.setBorder(null);
		signinButton.addMouseListener(this);
		signinButton.addActionListener(this);
		panel.add(signinButton);
		
		backButton=new JButton("Back");
		backButton.setBounds(610,375,80,30);
		backButton.setBackground(new Color(193,255,200));
		backButton.setBorder(null);
		backButton.addMouseListener(this);
		backButton.addActionListener(this);
		panel.add(backButton);
		
		
		ImageIcon bg=new ImageIcon("Image/signup.jpg");
		Image i1=bg.getImage().getScaledInstance(800,500,Image.SCALE_SMOOTH);
		ImageIcon i2=new ImageIcon(i1);
		
		bg1=new JLabel(i2);
		bg1.setSize(800,500);
		panel.add(bg1);

        this.add(panel);
	}
	
	public void mouseClicked(MouseEvent me){}
	public void mousePressed(MouseEvent me){}
	public void mouseReleased(MouseEvent me){}
	
	public void mouseEntered(MouseEvent me){
		if(me.getSource()==signinButton){
			signinButton.setBackground(new Color(120,240,119));
			signinButton.setForeground(Color.BLACK);
		}	
		if(me.getSource()==backButton){
			backButton.setBackground(new Color(120,240,119));
			backButton.setForeground(Color.BLACK);
		}	
	}
	public void mouseExited(MouseEvent me){
		if(me.getSource()==signinButton){
			signinButton.setBackground(new Color(193,255,200));
			signinButton.setForeground(Color.BLACK);
		}
		if(me.getSource()==backButton){
			backButton.setBackground(new Color(193,255,200));
			backButton.setForeground(Color.BLACK);
		}	
	}
	
	public void actionPerformed(ActionEvent ae){
		String command = ae.getActionCommand();
		if(signinButton.getText().equals(command)){
			String name ="",pass="",number="",email="",address="",gender="",
			            dt="",mnth="",yr="", dob="";
			
			name = nameField.getText();
			pass=passwordField.getText();
			address = addressField.getText();
			number=numberField.getText();
			email=emailField.getText();
			
			if(male.isSelected()){ gender = "Male";} 
			else if(female.isSelected()){ gender = "Female";} 
			else if(other.isSelected()){ gender = "Other";}
			else{}
				
			dt = date.getSelectedItem().toString();
			mnth = month.getSelectedItem().toString();
			yr = year.getSelectedItem().toString();
			dob = dt+"/"+mnth+"/"+yr;
			
			if((!name.isEmpty()) && (!gender.isEmpty()) && (!address.isEmpty())){
				int dialog = JOptionPane.YES_NO_OPTION;
				int result = JOptionPane.showConfirmDialog(this, "Are you sure you want to update these informations?", "Profile update?", dialog);
				if(result == 0){
					String oldName=u.getName();
					String oldPass=u.getPassword();
					String oldNumber=u.getNumber();
					String oldEmail=u.getEmail();
					String oldGender=u.getGender();
					String oldDOB=u.getDOB();
					String oldAddress=u.getAddress();
					user oldUser=new user(oldName,oldPass,oldNumber,oldEmail,oldGender,oldDOB,oldAddress);
					
					//updating new info
					u.setName(name);
					u.setPassword(pass);
					u.setNumber(number);
					u.setEmail(email);
					u.setGender(gender);
					u.setDOB(dob);
					u.setAddress(address);
					
					us.updateUser(oldUser,u);
					
					dialog = JOptionPane.YES_NO_OPTION;
					result = JOptionPane.showConfirmDialog(this, "Information updated. Do you want to stay on this page?", "Stay on this page?", dialog);
					if(result == 0){
						//do nothing
					}else{
						cProfile db = new cProfile(u,us,bs,as);
						db.setVisible(true);
						this.setVisible(false);
					}
				}else{
					//do nothing
				}
			}else{
				JOptionPane.showMessageDialog(this, "Can't update, information missing!");
			}
	}
	if(ae.getSource()==backButton){
			dispose();
			cProfile cp=new cProfile(u,us,bs,as);
			cp.setVisible(true);
		}
}
}