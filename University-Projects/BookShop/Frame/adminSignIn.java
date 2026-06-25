package Frame;
import Class.*;
import java.lang.*;
import java.awt.*;
import javax.swing.*;
import java.awt.event.*;
 
public class adminSignIn extends JFrame implements MouseListener,ActionListener
{
    JPanel panel;
    JLabel adminName,adminPassword,heading,bg1,adminLabel;
    JTextField nameField;
    JPasswordField passwordField;
	JButton signinButton,backButton;
	users us;
	books bs;
	admin a;
	admins as;
    public adminSignIn(users us,books bs,admins as){
        super("Signin");
		this.setSize(800,500);
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
		heading=new JLabel("Signin");
		heading.setBounds(150,35,200,100);
		heading.setFont(f);
		heading.setForeground(Color.WHITE);
		panel.add(heading);
		ImageIcon i=new ImageIcon("Image/admin4.png");
		Image a1=i.getImage().getScaledInstance(230,400,Image.SCALE_SMOOTH);
		ImageIcon a2=new ImageIcon(a1);
		adminLabel=new JLabel(a2);
		adminLabel.setBounds(500,40,230,400);
		panel.add(adminLabel);
		adminName=new JLabel("Username :");
        adminName.setBounds(70,130,100,50);
		adminName.setFont(f1);
        //adminName.setOpaque(true);
        panel.add(adminName);
		adminPassword=new JLabel("Password :");
        adminPassword.setBounds(70,200,100,50);
		adminPassword.setFont(f1);
        //adminPassword.setOpaque(true);
        panel.add(adminPassword);
		nameField=new JTextField();
        nameField.setBounds(200,140,150,25);
		nameField.setFont(f2);
		nameField.setBorder(null);
		nameField.setBackground(new Color(133,70,255));
        panel.add(nameField);
		
		passwordField=new JPasswordField();
        passwordField.setBounds(200,210,150,25);
		passwordField.setFont(f2);
		passwordField.setBorder(null);
		passwordField.setBackground(new Color(133,70,255));
		passwordField.setEchoChar('*');
        panel.add(passwordField);
		
		signinButton=new JButton("Signin");
		signinButton.setBounds(160,290,100,30);
		signinButton.setBackground(new Color(133,70,255));
		signinButton.addMouseListener(this);
		signinButton.addActionListener(this);
		signinButton.setBorder(null);
		panel.add(signinButton);
		
		backButton=new JButton("Back");
		backButton.setBounds(280,290,100,30);
		backButton.setBackground(new Color(133,70,255));
		backButton.addMouseListener(this);
		backButton.addActionListener(this);
		backButton.setBorder(null);
		panel.add(backButton);
		
		ImageIcon bg=new ImageIcon("Image/aSignIn.jpg");
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
			signinButton.setBackground(new Color(223,80,242));
			signinButton.setForeground(Color.BLACK);
		}
		if(me.getSource()==backButton){
			backButton.setBackground(new Color(223,80,242));
			backButton.setForeground(Color.BLACK);
		}
	}
	public void mouseExited(MouseEvent me){
		if(me.getSource()== signinButton){
			signinButton.setBackground(new Color(133,70,255));
			signinButton.setForeground(Color.BLACK);
		}
		if(me.getSource()==backButton){
			backButton.setBackground(new Color(133,70,255));
			backButton.setForeground(Color.BLACK);
		}
	}
	public void actionPerformed(ActionEvent ae){
		String command = ae.getActionCommand();
		if(signinButton.getText().equals(command)){
			
			String name = nameField.getText();
			String pass = passwordField.getText();// 
			int index = as.userExists(name);
			if(index == -1){
				JOptionPane.showMessageDialog(this, "User doesn't exist!");
			}else{
				a = as.checkCredentials(index,pass);
				if(a == null ){
					JOptionPane.showMessageDialog(this, "Password incorrect");
				}else{
					adminHome db = new adminHome(us,bs,a,as);
					db.setVisible(true);
					this.setVisible(false);
				}		
			}
	 }
		else if(ae.getSource()==backButton){
			dispose();
			intro2 in2=new intro2(us,bs,as);
			in2.setVisible(true);
		}
	}
}