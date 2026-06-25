package Frame;
import Class.*;
import javax.swing.*;
import java.awt.*;
import java.awt.event.*;



public class selectPaymentMethod extends JFrame implements ActionListener{

	private double totalAmount;
	private String price,img,quantt;
	private int totalQuantity,q;
	JLabel selctLabel,to;
	JButton bkashButton,rocketButton,nogodButton,dbblButton,backButton;
	JPanel panel,backgroundPanel;
	books bs;
	users us;
	user u;
	book b1;
	admins as;

	//String(img+price)Books obj+double totalamount
	public selectPaymentMethod(String img,String price,String quantt,int totalQuantity,int q,books bs,book b1,double totalAmount,user u,users us,admins as){
		this.u=u;
		this.us=us;
		this.bs=bs;
		this.b1=b1;
		this.as=as;
		this.img=img;
		this.price=price;
		this.quantt=quantt;
		this.totalAmount=totalAmount;
		this.totalQuantity=totalQuantity;
		this.q=q;
		
		this.setTitle("Payment Option");
		this.setSize(800,500);
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		this.setLocationRelativeTo(null);

		
		Font f=new Font("Arial",Font.BOLD,30);//plain
	
		ImageIcon bg=new ImageIcon("Image/selectoptionbackground.png");
		Image i1=bg.getImage().getScaledInstance(800,500,Image.SCALE_SMOOTH);
		ImageIcon i2=new ImageIcon(i1);

		
		panel=new JPanel();
		panel.setLayout(null);
		
		ImageIcon bkash = new ImageIcon("Image/bkash.png");
		ImageIcon nogod = new ImageIcon("Image/nogod.png");
		ImageIcon rocket = new ImageIcon("Image/rocket.png");
		ImageIcon dbbl = new ImageIcon("Image/dbbl.png");
		
		
		selctLabel =new JLabel("Select Payment Method");
		selctLabel.setBounds(150,40,400,50);
		selctLabel.setFont(f);
		selctLabel.setForeground(Color.WHITE);
		panel.add(selctLabel);
		
		
		bkashButton =new JButton(bkash);
		bkashButton.setBounds(20,100,bkash.getIconWidth(),bkash.getIconHeight());
		bkashButton.addActionListener(this);
		panel.add(bkashButton);
		
		
		nogodButton =new JButton(nogod);
		nogodButton.setBounds(220,100,nogod.getIconWidth(),nogod.getIconHeight());
		nogodButton.addActionListener(this);
		panel.add(nogodButton);
		
		rocketButton =new JButton(rocket);
		rocketButton.setBounds(410,100,rocket.getIconWidth(),rocket.getIconHeight());
		rocketButton.addActionListener(this);
		panel.add(rocketButton);
		
		dbblButton =new JButton(dbbl);
		dbblButton.setBounds(600,100,dbbl.getIconWidth(),dbbl.getIconHeight());
		dbblButton.addActionListener(this);
		panel.add(dbblButton);
		
		backButton=new JButton("Back");
		backButton.setBounds(200,320,80,30);
		backButton.addActionListener(this);
		panel.add(backButton);
		
		JLabel bg1=new JLabel(i2);
		bg1.setSize(800,500);
		panel.add(bg1);
		
		
		add(panel);
		
		
		
	}
	
	
	public void actionPerformed(ActionEvent ae){
		if(ae.getSource()==bkashButton){
			String bk="Image/bkashbackground.png";
			bookpayment b=new bookpayment(img,price,quantt,totalQuantity,q,bs,b1,totalAmount,bk,u,us,as);
			b.setVisible(true);
			this.setVisible(false);
		}
		
		else if(ae.getSource()==nogodButton){
			String ng="Image/nogodbackground.png";
			bookpayment b=new bookpayment(img,price,quantt,totalQuantity,q,bs,b1,totalAmount,ng,u,us,as);
			b.setVisible(true);
			this.setVisible(false);
		}
		
		else if(ae.getSource()==rocketButton){
			String rk="Image/rocketbackground.png";
			bookpayment b=new bookpayment(img,price,quantt,totalQuantity,q,bs,b1,totalAmount,rk,u,us,as);
			b.setVisible(true);
			this.setVisible(false);
		}
		
		
		else if(ae.getSource()==dbblButton){
			String d="Image/dbblbackground.png";
			bookpayment b=new bookpayment(img,price,quantt,totalQuantity,q,bs,b1,totalAmount,d,u,us,as);
			b.setVisible(true);
			this.setVisible(false);
		}else if(ae.getSource()==backButton){
			
			buy sl= new buy(img,price,quantt,bs,b1,u,us,as);
			sl.setVisible(true);
			this.setVisible(false);
		}
		
		
	}
	
	
	
	
	
	
}