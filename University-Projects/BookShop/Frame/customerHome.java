package Frame;
import Class.*;
import java.lang.*;
import java.awt.*;
import javax.swing.*;
import java.awt.event.*;

public class customerHome extends JFrame implements MouseListener,ActionListener{
	JPanel panel;
	JLabel bg,profileImgLabel,bookImgLabel,nameLabel,qLabel;
	JButton profileButton,buyBooksButton,backButton,aboutUsButton;
	users us;
	user u;
	books bs;
	admins as;
	
	public customerHome(user u,users us,books bs,admins as){
		super("customer home page");
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
		
		Font myFont = new Font("Cambria", Font.PLAIN, 25);
		
		nameLabel = new JLabel("Hi, "+u.getName()); 
		nameLabel.setBounds(435,30,400,30);
		//nameLabel.setForeground(Color.White);
		nameLabel.setFont(myFont);
		panel.add(nameLabel);
		
		ImageIcon a=new ImageIcon("Image/profile.png");
		Image a1=a.getImage().getScaledInstance(150,150,Image.SCALE_SMOOTH);
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
		
		ImageIcon q=new ImageIcon("qmark.png");
		Image q1=q.getImage().getScaledInstance(100,100,Image.SCALE_SMOOTH);
		ImageIcon q2=new ImageIcon(q1);
		
		qLabel=new JLabel(q2);
		qLabel.setBounds(50,50,100,100);//15-18 math,mcq
		panel.add(qLabel);
		
		aboutUsButton=new JButton("About us");
		aboutUsButton.setBounds(160,70,100,30);
		aboutUsButton.setBackground(new Color(133,70,255));
		aboutUsButton.addMouseListener(this);
		aboutUsButton.addActionListener(this);
		aboutUsButton.setBorder(null);
		panel.add(aboutUsButton);
		
		profileButton=new JButton("Profile");
		profileButton.setBounds(125,300,100,30);
		profileButton.setBackground(new Color(133,70,255));
		profileButton.addMouseListener(this);
		profileButton.addActionListener(this);
		profileButton.setBorder(null);
		panel.add(profileButton);
		
		buyBooksButton=new JButton("Buy books");
		buyBooksButton.setBounds(331,300,100,30);
		buyBooksButton.setBackground(new Color(133,70,255));
		buyBooksButton.addMouseListener(this);
		buyBooksButton.addActionListener(this);
		buyBooksButton.setBorder(null);
		panel.add(buyBooksButton);
		
		backButton=new JButton("Log out");
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
		if(me.getSource()==buyBooksButton){
			buyBooksButton.setBackground(new Color(223,80,242));
			buyBooksButton.setForeground(Color.BLACK);
		}
		if(me.getSource()==backButton){
			backButton.setBackground(new Color(223,80,242));
			backButton.setForeground(Color.BLACK);
		}
		if(me.getSource()==aboutUsButton){
			aboutUsButton.setBackground(new Color(223,80,242));
			aboutUsButton.setForeground(Color.BLACK);
		}
		if(me.getSource()==profileButton){
			profileButton.setBackground(new Color(223,80,242));
			profileButton.setForeground(Color.BLACK);
		}
	}
	public void mouseExited(MouseEvent me){
		if(me.getSource()==buyBooksButton){
			buyBooksButton.setBackground(new Color(133,70,255));
			buyBooksButton.setForeground(Color.BLACK);
		}
		if(me.getSource()==backButton){
			backButton.setBackground(new Color(133,70,255));
			backButton.setForeground(Color.BLACK);
		}
		if(me.getSource()==aboutUsButton){
			aboutUsButton.setBackground(new Color(133,70,255));
			aboutUsButton.setForeground(Color.BLACK);
		}
		if(me.getSource()==profileButton){
			profileButton.setBackground(new Color(133,70,255));
			profileButton.setForeground(Color.BLACK);
		}
	}
	
	public void actionPerformed(ActionEvent ae){
		if(ae.getSource()==buyBooksButton){
			dispose();
			selectbook s=new selectbook(bs,u,us,as);
			s.setVisible(true);
			//cb.setVisible(true);
		}
		if(ae.getSource()==backButton){
			dispose();
			customerSignin csin=new customerSignin(us,bs,as);
			csin.setVisible(true);
		}
		if(ae.getSource()==profileButton){
			dispose();
			cProfile cp=new cProfile(u,us,bs,as);
			cp.setVisible(true);
		}
		if(ae.getSource()==aboutUsButton){
			dispose();
			aboutUs cp=new aboutUs(u,us,bs,as);
			cp.setVisible(true);
		}
	}
}