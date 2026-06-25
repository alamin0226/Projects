package  Frame;
import Class.*;
import java.lang.*;
import java.awt.*;
import javax.swing.*;
import java.awt.event.*;


public class aboutUs extends JFrame implements MouseListener,ActionListener{
	JPanel panel;
	JLabel id1,id2,id3,id4,s1,s2,s3,s4,bg,tirthoImgLabel,tirthoLabel,alaminImgLabel,alaminLabel,purbaImgLabel,purbaLabel,rafitImgLabel,rafitLabel;
	JButton backButton;
	users us;
	user u;
	books bs;
	admins as;
	public aboutUs(user u,users us,books bs,admins as){
		super("about us");
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
		
		
		ImageIcon t=new ImageIcon("Image/tirtho.jpg");
		Image t1=t.getImage().getScaledInstance(100,100,Image.SCALE_SMOOTH);
		ImageIcon t2=new ImageIcon(t1);
		
		tirthoImgLabel=new JLabel(t2);
		tirthoImgLabel.setBounds(50,20,100,100);
		panel.add(tirthoImgLabel);
		
		tirthoLabel=new JLabel("SUDORTION MALAKER TIRTHO");
		tirthoLabel.setBounds(50,130,200,20);
		tirthoLabel.setForeground(Color.WHITE);
		panel.add(tirthoLabel);
		
		id1=new JLabel("23-53533-3");
		id1.setBounds(50,150,200,20);
		id1.setForeground(Color.WHITE);
		panel.add(id1);
		
		
		ImageIcon a=new ImageIcon("Image/alamin.jpg");
		Image a1=a.getImage().getScaledInstance(100,100,Image.SCALE_SMOOTH);
		ImageIcon a2=new ImageIcon(a1);
		
		alaminImgLabel=new JLabel(a2);
		alaminImgLabel.setBounds(50,200,100,100);//15-18 math,mcq
		panel.add(alaminImgLabel);
		
		alaminLabel=new JLabel("MD AL AMIN");
		alaminLabel.setBounds(50,310,200,20);
		alaminLabel.setForeground(Color.WHITE);
		panel.add(alaminLabel);
		
		id2=new JLabel("23-52648-2");
		id2.setBounds(50,330,200,20);
		id2.setForeground(Color.WHITE);
		panel.add(id2);
		
		ImageIcon p=new ImageIcon("Image/purba.jpg");
		Image p1=p.getImage().getScaledInstance(100,100,Image.SCALE_SMOOTH);
		ImageIcon p2=new ImageIcon(p1);
		
		
		purbaImgLabel=new JLabel(p2);
		purbaImgLabel.setBounds(450,20,100,100);//15-18 math,mcq
		panel.add(purbaImgLabel);
		
		purbaLabel=new JLabel("JOYETA GHATAK ROY PURBA");
		purbaLabel.setBounds(450,130,200,20);
		purbaLabel.setForeground(Color.WHITE);
		panel.add(purbaLabel);
		
		id3=new JLabel("23-53557-3");
		id3.setBounds(450,150,200,20);
		id3.setForeground(Color.WHITE);
		panel.add(id3);
		
		ImageIcon r=new ImageIcon("Image/rafit.jpg");
		Image r1=r.getImage().getScaledInstance(100,100,Image.SCALE_SMOOTH);
		ImageIcon r2=new ImageIcon(r1);
		
		rafitImgLabel=new JLabel(r2);
		rafitImgLabel.setBounds(450,200,100,100);//15-18 math,mcq
		panel.add(rafitImgLabel);
		
		rafitLabel=new JLabel("Md Rafit Rahad");
		rafitLabel.setBounds(450,310,200,20);
		rafitLabel.setForeground(Color.WHITE);
		panel.add(rafitLabel);
		
		id1=new JLabel("23-52476-2");
		id1.setBounds(450,330,200,20);
		id1.setForeground(Color.WHITE);
		panel.add(id1);
		
		backButton=new JButton("Back");
		backButton.setBounds(700,50,60,30);
		backButton.setBackground(new Color(133,70,255));
		backButton.addMouseListener(this);
		backButton.addActionListener(this);
		backButton.setBorder(null);	
		panel.add(backButton);
		
		ImageIcon img=new ImageIcon("Image/aboutus.jpg");
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
		if(me.getSource()==backButton){
			backButton.setBackground(new Color(223,80,242));
			backButton.setForeground(Color.BLACK);
		}
	}
	public void mouseExited(MouseEvent me){
		if(me.getSource()==backButton){
			backButton.setBackground(new Color(133,70,255));
			backButton.setForeground(Color.BLACK);
		}
	}
	
	public void actionPerformed(ActionEvent ae){
		if(ae.getSource()==backButton){
			dispose();
			customerHome csin=new customerHome(u,us,bs,as);
			csin.setVisible(true);
		}
	}
}