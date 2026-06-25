package Frame;
import Class.*;
import java.lang.*;
import java.awt.*;
import javax.swing.*;
import java.awt.event.*;
 
public class adminHome extends JFrame implements MouseListener,ActionListener{
	JPanel panel;
	JLabel bg,profileImgLabel,bookImgLabel;
	JButton profileButton,bookSectionButton,backButton,findbookSectionButton,updateQuantityButton;
	users us;
	books bs;
	admin a;
	admins as;
	public adminHome(users us,books bs,admin a,admins as){
		super("Admin home page");
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
		
		ImageIcon i=new ImageIcon("Image/admin.png");
		Image a1=i.getImage().getScaledInstance(150,150,Image.SCALE_SMOOTH);
		ImageIcon a2=new ImageIcon(a1);
		
		profileImgLabel=new JLabel(a2);
		profileImgLabel.setBounds(100,140,150,150);
		panel.add(profileImgLabel);
		
		ImageIcon c=new ImageIcon("Image/book.png");
		Image c1=c.getImage().getScaledInstance(150,150,Image.SCALE_SMOOTH);
		ImageIcon c2=new ImageIcon(c1);
		
		bookImgLabel=new JLabel(c2);
		bookImgLabel.setBounds(300,140,150,150);//15-18 math,mcq
		panel.add(bookImgLabel);
		
		profileButton=new JButton("Profile");
		profileButton.setBounds(125,300,80,30);
		profileButton.setBackground(new Color(133,70,255));
		profileButton.addMouseListener(this);
		profileButton.addActionListener(this);
		profileButton.setBorder(null);
		panel.add(profileButton);
		
		updateQuantityButton=new JButton("Update Quantity");
		updateQuantityButton.setBounds(230,240,180,30);
		updateQuantityButton.setBackground(new Color(133,70,255));
		updateQuantityButton.addActionListener(this);
		updateQuantityButton.setBorder(null);
		panel.add(updateQuantityButton);
		
		bookSectionButton=new JButton("Upcoming");
		bookSectionButton.setBounds(280,300,80,30);
		bookSectionButton.setBackground(new Color(133,70,255));
		bookSectionButton.addMouseListener(this);
		bookSectionButton.addActionListener(this);
		bookSectionButton.setBorder(null);
		panel.add(bookSectionButton);
		
		findbookSectionButton=new JButton("find book");
		findbookSectionButton.setBounds(420,300,80,30);
		findbookSectionButton.setBackground(new Color(133,70,255));
		findbookSectionButton.addMouseListener(this);
		findbookSectionButton.addActionListener(this);
		findbookSectionButton.setBorder(null);
		panel.add(findbookSectionButton);
		
		backButton=new JButton("Back");
		backButton.setBounds(180,355,200,30);
		backButton.setBackground(new Color(133,70,255));
		backButton.addMouseListener(this);
		backButton.addActionListener(this);
		backButton.setBorder(null);	
		panel.add(backButton);
		
		ImageIcon img=new ImageIcon("Image/customerHome.jpg");
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
		if(me.getSource()==bookSectionButton){
			bookSectionButton.setBackground(new Color(223,80,242));
			bookSectionButton.setForeground(Color.BLACK);
		}
		if(me.getSource()==backButton){
			backButton.setBackground(new Color(223,80,242));
			backButton.setForeground(Color.BLACK);
		}
		if(me.getSource()==profileButton){
			profileButton.setBackground(new Color(223,80,242));
			profileButton.setForeground(Color.BLACK);
		}
		if(me.getSource()==findbookSectionButton){
			findbookSectionButton.setBackground(new Color(223,80,242));
			findbookSectionButton.setForeground(Color.BLACK);
		}
	}
	public void mouseExited(MouseEvent me){
		if(me.getSource()==bookSectionButton){
			bookSectionButton.setBackground(new Color(133,70,255));
			bookSectionButton.setForeground(Color.BLACK);
		}
		if(me.getSource()==backButton){
			backButton.setBackground(new Color(133,70,255));
			backButton.setForeground(Color.BLACK);
		}
		if(me.getSource()==profileButton){
			profileButton.setBackground(new Color(133,70,255));
			profileButton.setForeground(Color.BLACK);
		}
	}
	public void actionPerformed(ActionEvent ae){
		if(ae.getSource()==bookSectionButton){
			dispose();
			Detective dt = new Detective (us,bs,a,as);
			dt.setVisible(true);
		}
		else if(ae.getSource()==backButton){
			dispose();
			adminSignIn asin=new adminSignIn(us,bs,as);
			asin.setVisible(true);
		}
		
		else if(ae.getSource()==findbookSectionButton){
			dispose();
			customizeBooks cbs = new customizeBooks(us,bs,a,as);
			cbs.setVisible(true);
		}
	    if(ae.getSource()==backButton){
			dispose();
			adminSignIn asin=new adminSignIn(us,bs,as);
			asin.setVisible(true);
		}
		 else if(ae.getSource()==updateQuantityButton){
			 
			 dispose();
			Asearch asin=new Asearch(us,bs,a,as);
			asin.setVisible(true);
			
		}
		if(ae.getSource()==profileButton){
			dispose();
			aProfile ap=new aProfile(us,bs,a,as);
			ap.setVisible(true);
		}
	}
}
