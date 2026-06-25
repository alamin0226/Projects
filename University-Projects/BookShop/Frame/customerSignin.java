package Frame;
import Class.*;
import java.lang.*;
import java.awt.*;
import javax.swing.*;
import java.awt.event.*;

public class customerSignin extends JFrame implements MouseListener,ActionListener
{
    JPanel panel;
	JToggleButton tglB,TglB;
    JLabel customerName,customerPassword,heading,heading2,bg1;
    JTextField nameField;
    JPasswordField passwordField;
	JButton signinButton,signupButton,backButton,forgotButton,eyeButton;
	ImageIcon notEye,eye;
	user u;
	users us = null;
	books bs;
	admins as;

    public customerSignin(users us,books bs,admins as){
        super("Signin or signup");
		this.setSize(850,500);
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		this.setLocationRelativeTo(null);
		this.setResizable(false);
		this.us=us;
		this.bs=bs;
		this.as=as;

        panel=new JPanel();
        panel.setLayout(null);
		
		//Color ccl = new Color(195,215,235);
		Font f=new Font("Arial",Font.BOLD,20);
		Font f1=new Font("Arial",Font.BOLD,15);
		Font f2=new Font("Arial",Font.PLAIN,17);
		
		notEye = new ImageIcon("icon2.png");
		eye = new ImageIcon("icon3.png");
		
		heading=new JLabel("Signin");
		heading.setBounds(590,10,200,100);
		heading.setFont(f);
		heading.setForeground(Color.WHITE);
		panel.add(heading);

        customerName=new JLabel("Username :");
        customerName.setBounds(500,97,100,50);
		customerName.setFont(f1);
        //customerName.setOpaque(true);
        panel.add(customerName);
        
        customerPassword=new JLabel("Password :");
        customerPassword.setBounds(500,167,100,50);
		customerPassword.setFont(f1);
        //customerPassword.setOpaque(true);
        panel.add(customerPassword);

        nameField=new JTextField();
        nameField.setBounds(600,108,150,25);
		nameField.setFont(f2);
		nameField.setBorder(null);
		nameField.setBackground(new Color(133,70,255));
        panel.add(nameField);

        passwordField=new JPasswordField();
        passwordField.setBounds(600,178,150,25);
		passwordField.setFont(f2);
		passwordField.setBorder(null);
		passwordField.setBackground(new Color(133,70,255));
		passwordField.setEchoChar('*');
        panel.add(passwordField);
		
		tglB = new JToggleButton("",eye);
		tglB.setBounds(770,178,25,26);
		tglB.setBorder(null);
		tglB.setOpaque(false);
		tglB.setCursor(new Cursor(Cursor.HAND_CURSOR));
        tglB.setFocusPainted(false);
        tglB.setBorder(BorderFactory.createEmptyBorder(4, 4, 4, 4));
        tglB.setContentAreaFilled(false);
		tglB.addMouseListener(this);
		//tglB.setVisible(false);
		
		
		TglB = new JToggleButton("",notEye);
		TglB.setBounds(770,178,25,26);
		TglB.setBorder(null);
		TglB.setOpaque(false);
		TglB.setCursor(new Cursor(Cursor.HAND_CURSOR));
        TglB.setFocusPainted(false);
        TglB.setContentAreaFilled(false);
		TglB.addMouseListener(this);
		TglB.setVisible(false);
		
		
		
		/*ImageIcon src=new ImageIcon("search.jpg");
		Image s1=src.getImage().getScaledInstance(50,30,Image.SCALE_SMOOTH);
		ImageIcon s2=new ImageIcon(s1);
		
		searchButton=new JButton(s2);
		searchButton.setBounds(535,30,50,30);
		//searchButton.setBackground(new Color(133,70,255));
		searchButton.addMouseListener(this);
		searchButton.addActionListener(this);
		//searchButton.setBorder(null);	
		panel.add(searchButton);*/
		
		signupButton=new JButton("Signup");
		signupButton.setBounds(575,345,100,30);//500,240,100,30
		signupButton.setBackground(new Color(133,70,255));
		signupButton.addMouseListener(this);
		signupButton.addActionListener(this);
		signupButton.setBorder(null);//99,37,212
		panel.add(signupButton);
		
		heading=new JLabel("Don't have any account? Then");
		heading.setBounds(460,270,300,100);
		heading.setFont(f);
		heading.setForeground(Color.WHITE);
		panel.add(heading);
		
		signinButton=new JButton("Signin");
		signinButton.setBounds(500,240,100,30);//575,345,100,30
		signinButton.setBackground(new Color(133,70,255));
		signinButton.addMouseListener(this);
		signinButton.addActionListener(this);
		signinButton.setBorder(null);
		panel.add(signinButton);
		
		backButton=new JButton("Back");
		backButton.setBounds(650,240,100,30);
		backButton.setBackground(new Color(133,70,255));
		backButton.addMouseListener(this);
		backButton.addActionListener(this);
		backButton.setBorder(null);
		panel.add(backButton);
		
		forgotButton=new JButton("Forgot password?");
		forgotButton.setBounds(550,400,150,30);
		forgotButton.setBackground(new Color(99,37,212));
		forgotButton.addMouseListener(this);
		forgotButton.addActionListener(this);
		forgotButton.setBorder(null);//99,37,212
		forgotButton.setFont(f1);
		forgotButton.setForeground(Color.RED);
		panel.add(forgotButton);
		
		ImageIcon bg=new ImageIcon("Image/bg3.jpg");
		Image i1=bg.getImage().getScaledInstance(850,500,Image.SCALE_SMOOTH);
		ImageIcon i2=new ImageIcon(i1);
		
		bg1=new JLabel(i2);
		bg1.setSize(850,500);
		panel.add(bg1);
		
		panel.add(tglB);
		panel.add(TglB);
        this.add(panel);
    }
	
	public void mouseClicked(MouseEvent me){
		
		if(me.getSource()==tglB){
			TglB.setVisible(true);
			tglB.setVisible(false);
			passwordField.setEchoChar((char)0);
			
		}
		else if(me.getSource()==TglB){
			TglB.setVisible(false);
			tglB.setVisible(true);
			passwordField.setEchoChar('*');
			
		}
		else{
			
		}
	}
	public void mousePressed(MouseEvent me){}
	public void mouseReleased(MouseEvent me){}

	public void mouseEntered(MouseEvent me){
		if(me.getSource()==signupButton){
			signupButton.setBackground(new Color(223,80,242));
			signupButton.setForeground(Color.BLACK);
		}
		if(me.getSource()==signinButton){
			signinButton.setBackground(new Color(223,80,242));
			signinButton.setForeground(Color.BLACK);
		}
		if(me.getSource()==backButton){
			backButton.setBackground(new Color(223,80,242));
			backButton.setForeground(Color.BLACK);
		}
		if(me.getSource()==forgotButton){
			forgotButton.setBackground(new Color(223,80,242));
			forgotButton.setForeground(Color.BLACK);
		}
		if(me.getSource()==eyeButton){
			eyeButton.setBackground(new Color(101,88,216));
			//eyeButton.setForeground(Color.BLACK);
		}
	}
	public void mouseExited(MouseEvent me){
		if(me.getSource()== signupButton){
			signupButton.setBackground(new Color(133,70,255));
			signupButton.setForeground(Color.BLACK);
		}
		if(me.getSource()== signinButton){
			signinButton.setBackground(new Color(133,70,255));
			signinButton.setForeground(Color.BLACK);
		}
		if(me.getSource()==backButton){
			backButton.setBackground(new Color(133,70,255));
			backButton.setForeground(Color.BLACK);
		}
		if(me.getSource()==forgotButton){
			forgotButton.setBackground(new Color(133,70,255));
			forgotButton.setForeground(Color.BLACK);
		}
		if(me.getSource()==eyeButton){
			eyeButton.setBackground(new Color(101,88,216));
			//eyeButton.setForeground(Color.BLACK);
		}
	}
	public void actionPerformed(ActionEvent ae){
		String command = ae.getActionCommand();
		if(ae.getSource()== signupButton){
			dispose();
			customerSignup cUn = new customerSignup (us,bs,as);
			cUn.setVisible(true);
		}
		if(signinButton.getText().equals(command)){
			String name = nameField.getText();
			String pass = passwordField.getText();
			
			int index = us.userExists(name);
			if(index == -1){
				JOptionPane.showMessageDialog(this, "User doesn't exist!");
			}else{
				u = us.checkCredentials(index,pass);
				if(u == null ){
					JOptionPane.showMessageDialog(this, "Password incorrect");
				}else{
					customerHome db = new customerHome(u,us,bs,as);
					db.setVisible(true);
					this.setVisible(false);
				}		
			}
	 }
	 if(ae.getSource()==backButton){
			dispose();
			intro2 in2=new intro2(us,bs,as);
			in2.setVisible(true);
		}
		if(ae.getSource()==forgotButton){
			dispose();
			forgotPass in2=new forgotPass(us,bs,as);
			in2.setVisible(true);
		}

}
}