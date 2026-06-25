package Frame;
import Class.*;
import java.lang.*;
import java.awt.*;
import javax.swing.*;
import java.awt.event.*;

public class forgotPass2 extends JFrame implements MouseListener,ActionListener
{
    JPanel panel;
    JLabel customerName,customerPassword,conformPassword,bg1;
    JTextField nameField;
    JPasswordField passwordField,conformPasswordField;
	JButton backButton,saveButton;
	users us;
	user u;
	cProfile cp;
	books bs;
	admins as;
    public forgotPass2(user u,users us,cProfile cp,books bs,admins as){
        super("forgotPassword? then change....");
		this.setSize(800,500);
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		this.setLocationRelativeTo(null);
		this.setResizable(false);
		//this.us=us;
		this.u=u;
		this.us=us;
		this.cp=cp;
		this.bs=bs;
		this.as=as;

        panel=new JPanel();
        panel.setLayout(null);
		
		//Color ccl = new Color(195,215,235);
		Font f=new Font("Arial",Font.BOLD,20);
		Font f1=new Font("Arial",Font.BOLD,15);
		Font f2=new Font("Arial",Font.PLAIN,17);

       /* customerName=new JLabel("Username :");
        customerName.setBounds(250,97,100,50);
		customerName.setFont(f1);
        //customerName.setOpaque(true);
        panel.add(customerName);*/
        
        customerPassword=new JLabel("Type new password :");
        customerPassword.setBounds(200,167,170,50);
		customerPassword.setFont(f1);
        //customerPassword.setOpaque(true);
        panel.add(customerPassword);
		
		conformPassword=new JLabel("Conform password  :");
		conformPassword.setBounds(200,237,200,20);
		conformPassword.setFont(f1);
		panel.add(conformPassword);

      /*  nameField=new JTextField();
        nameField.setBounds(360,108,150,25);
		nameField.setFont(f2);
		nameField.setBorder(null);
		nameField.setBackground(new Color(253,253,253));
        panel.add(nameField);

        passwordField=new JPasswordField();
        passwordField.setBounds(360,178,150,25);
		passwordField.setFont(f2);
		passwordField.setBorder(null);
		passwordField.setBackground(new Color(253,253,253));
		passwordField.setEchoChar('*');
        panel.add(passwordField);*/
		
		passwordField=new JPasswordField();
        passwordField.setBounds(360,178,150,25);
		passwordField.setBackground(new Color(253,253,253));
		passwordField.setFont(f2);
		passwordField.setBorder(null);
		passwordField.setEchoChar('*');
        panel.add(passwordField);
		
		conformPasswordField=new JPasswordField();
		conformPasswordField.setBounds(360,238,150,25);
		conformPasswordField.setFont(f2);
		conformPasswordField.setBorder(null);
		conformPasswordField.setBackground(new Color(253,253,253));
		panel.add(conformPasswordField);
		
		saveButton=new JButton("Save");
		saveButton.setBounds(240,323,100,30);//575,345,100,30
		saveButton.setBackground(new Color(253,253,253));
		saveButton.addMouseListener(this);
		saveButton.addActionListener(this);
		saveButton.setBorder(null);
		panel.add(saveButton);
		
		backButton=new JButton("Back");
		backButton.setBounds(400,323,100,30);
		backButton.setBackground(new Color(253,253,253));
		backButton.addMouseListener(this);
		backButton.addActionListener(this);
		backButton.setBorder(null);
		panel.add(backButton);
		
		
		ImageIcon bg=new ImageIcon("Image/forgotPass.jpg");
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
		if(me.getSource()==saveButton){
			saveButton.setBackground(new Color(223,80,242));
			saveButton.setForeground(Color.BLACK);
		}
		if(me.getSource()==backButton){
			backButton.setBackground(new Color(223,80,242));
			backButton.setForeground(Color.BLACK);
		}
	}
	public void mouseExited(MouseEvent me){
		if(me.getSource()== saveButton){
			saveButton.setBackground(new Color(253,253,253));
			saveButton.setForeground(Color.BLACK);
		}
		if(me.getSource()== backButton){
			backButton.setBackground(new Color(253,253,253));
			backButton.setForeground(Color.BLACK);
		}
	}
	public void actionPerformed(ActionEvent ae){
		String command = ae.getActionCommand();
		//String command = ae.getActionCommand();
		if(saveButton.getText().equals(command)){
			String pass="",conform="";

			conform=conformPasswordField.getText();
			pass=passwordField.getText();
			
			if((!pass.isEmpty()) && pass.equals(conform)){
				//if(pass.equals(conform)){
				int dialog = JOptionPane.YES_NO_OPTION;
				int result = JOptionPane.showConfirmDialog(this, "Are you sure you want to update these informations?", "Profile update?", dialog);
				if(result == 0){
					//String oldPass=u.getPassword();
					//user oldUser=new user(oldName,oldPass,oldNumber,oldEmail,oldGender,oldDOB,oldAddress);
					
					//updating new info
					String oldName=u.getName();
					String oldPass=u.getPassword();
					String oldNumber=u.getNumber();
					String oldEmail=u.getEmail();
					String oldGender=u.getGender();
					String oldDOB=u.getDOB();
					String oldAddress=u.getAddress();
					user oldUser=new user(oldName,oldPass,oldNumber,oldEmail,oldGender,oldDOB,oldAddress);
					
					u.setPassword(pass);
					
					us.updateUser(oldUser,u);
					
					dialog = JOptionPane.YES_NO_OPTION;
					result = JOptionPane.showConfirmDialog(this, "Information updated. Do you want to stay on this page?", "Stay on this page?", dialog);
					if(result == 0){
						//do nothing
					}else{
						forgotPass db = new forgotPass(us,bs,as);
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
			forgotPass cHm = new forgotPass (us,bs,as);
			cHm.setVisible(true);
		}
	}
}