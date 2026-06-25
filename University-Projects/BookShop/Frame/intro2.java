package Frame;
import Class.*;
import java.lang.*;
import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
public class intro2 extends JFrame implements MouseListener,ActionListener{
	JPanel panel;
	JLabel heading,bg1,adminLabel,customerLabel;
	JButton adminButton,customerButton;
	users us;
	books bs;
	admins as;
	public intro2(users us,books bs,admins as){
		super("Login as");
		this.setSize(800,500);
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		this.setLocationRelativeTo(null);
		this.setResizable(false);
		this.us=us;
		this.bs=bs;
		this.as=as;

        panel=new JPanel();
        panel.setLayout(null);
		
		Font f=new Font("Arial",Font.BOLD,30);
		
		heading=new JLabel("Login As");
		heading.setBounds(330,50,300,100);
		heading.setFont(f);
		heading.setForeground(Color.WHITE);
		panel.add(heading);
		
		ImageIcon a=new ImageIcon("Image/admin.png");
		Image a1=a.getImage().getScaledInstance(150,150,Image.SCALE_SMOOTH);
		ImageIcon a2=new ImageIcon(a1);
		
		adminLabel=new JLabel(a2);
		adminLabel.setBounds(220,140,150,150);
		panel.add(adminLabel);
		
		ImageIcon c=new ImageIcon("Image/customer.png");
		Image c1=c.getImage().getScaledInstance(100,100,Image.SCALE_SMOOTH);
		ImageIcon c2=new ImageIcon(c1);
		
		customerLabel=new JLabel(c2);
		customerLabel.setBounds(450,170,100,100);
		panel.add(customerLabel);
		
		adminButton=new JButton("Admin");
		adminButton.setBounds(245,290,100,30);
		adminButton.addMouseListener(this);
		adminButton.addActionListener(this);
		adminButton.setBackground(new Color(133,70,255));
		panel.add(adminButton);
		
		customerButton=new JButton("Customer");
		customerButton.setBounds(447,290,100,30);
		customerButton.addMouseListener(this);
		customerButton.addActionListener(this);
		customerButton.setBackground(new Color(133,70,255));
		panel.add(customerButton);
		
		ImageIcon bg=new ImageIcon("Image/bg2.jpg");
		Image i1=bg.getImage().getScaledInstance(800,500,Image.SCALE_SMOOTH);
		ImageIcon i2=new ImageIcon(i1);
		
		bg1=new JLabel(i2);
		bg1.setSize(800,500);
		panel.add(bg1);
		
		this.add(panel);
		//bg1.add(panel);
	}
	
	public void mouseClicked(MouseEvent me){}
	public void mousePressed(MouseEvent me){}
	public void mouseReleased(MouseEvent me){}

	public void mouseEntered(MouseEvent me){
		if(me.getSource()==customerButton){
			customerButton.setBackground(new Color(223,80,242));
			customerButton.setForeground(Color.BLACK);
		}	
		if(me.getSource()==adminButton){
			adminButton.setBackground(new Color(223,80,242));
			adminButton.setForeground(Color.BLACK);
		}	
	}
	public void mouseExited(MouseEvent me){
		if(me.getSource()== customerButton){
			customerButton.setBackground(new Color(133,70,255));
			customerButton.setForeground(Color.BLACK);
		}
		if(me.getSource()== adminButton){
			adminButton.setBackground(new Color(133,70,255));
			adminButton.setForeground(Color.BLACK);
		}
	}
	public void actionPerformed(ActionEvent ae){
		if(ae.getSource()== customerButton){
			dispose();
			customerSignin cIn = new customerSignin (us,bs,as);
			cIn.setVisible(true);
		}
		if(ae.getSource()== adminButton){
			dispose();
			adminSignIn ain=new adminSignIn( us,bs,as);
			ain.setVisible(true);
			//adminStart cIn = new adminStart (us,bs);
		}
	}
}