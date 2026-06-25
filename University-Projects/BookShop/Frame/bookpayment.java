package Frame;
import Class.*;
import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.io.*;
public class bookpayment extends JFrame implements ActionListener{
	private double amount,totalAmount;
	private String price,img,p,str,quantt,avablquantity;
	private int totalQuantity,q,availableQuantity;
	JLabel numberLabel,pinLabel,priceLabel;
	JPanel panel;
	JTextField numberField,pinField,priceField;
	JButton backButton,confirmPaymentButton;
	books bs;
	users us;
	user u;
	book b;
	admins as;
    public bookpayment(String img,String price,String quantt,int totalQuantity,int q,books bs,book b,double totalAmount,String p,user u,users us,admins as){
		this.u=u;
		this.us=us;
		this.p=p;
		this.bs=bs;
		this.b=b;
		this.img=img;
		this.price=price;
		this.quantt=quantt;
		this.totalQuantity=totalQuantity;
		this.q=q;
		this.totalAmount=totalAmount;
		this.as=as;
		
		this.setTitle("BookShop");
		this.setSize(800,500);
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		this.setLocationRelativeTo(null);
		
		try{
			str = String.valueOf(totalAmount);
		}catch(Exception ex){}
		
		Font f=new Font("Arial",Font.BOLD,20);
		
		
		panel=new JPanel();
		panel.setLayout(null);
		
		
		JLabel numberLabel = new JLabel("Number: ");
		numberLabel.setBounds(100,80,100,30);
		numberLabel.setFont(f);
		//numberLabel.setForeground(Color.RED);
		panel.add(numberLabel);
		
		numberField = new JTextField();
		numberField.setBounds(220,80,150,30);
		panel.add(numberField);
	
		JLabel pinLabel = new JLabel("Pin No:");
		pinLabel.setBounds(100,150,100,30);
		pinLabel.setFont(f);
		//pinLabel.setForeground(Color.RED);
		panel.add(pinLabel);
	
		pinField = new JTextField();
		pinField.setBounds(220,150,150,30);
		panel.add(pinField);
	
		priceLabel = new JLabel("Amount :"+str);
		priceLabel.setBounds(100,210,400,30);
		priceLabel.setFont(f);
		//priceLabel.setForeground(Color.RED);
		panel.add(priceLabel);
		 
		 
		 
		backButton=new JButton("Back");
		backButton.setBounds(200,320,80,30);
		backButton.addActionListener(this);
		panel.add(backButton);
		
		confirmPaymentButton=new JButton("Confirm Payment");
		confirmPaymentButton.setBounds(400,320,150,30);
		confirmPaymentButton.addActionListener(this);
		panel.add(confirmPaymentButton);
		
		
		ImageIcon bg=new ImageIcon(p);
		Image i1=bg.getImage().getScaledInstance(800,500,Image.SCALE_SMOOTH);
		ImageIcon i2=new ImageIcon(i1);
		
		JLabel bg2=new JLabel(i2);
		bg2.setSize(800,500);
		panel.add(bg2);
		
		
		getContentPane().setBackground(Color.BLUE);
		
		add(panel);
		
		
		
	
    }
	
	public void actionPerformed(ActionEvent ae){
		
		if(ae.getSource()==confirmPaymentButton){
			
			String number,pin;
			number=numberField.getText();
			pin=pinField.getText();
			
			if(!number.isEmpty() && !pin.isEmpty()){ 
			
			availableQuantity=totalQuantity-q;
			try{
			avablquantity = String.valueOf(availableQuantity);
		}catch(Exception ex){}
			
					String oldName = b.getName();
					String oldISBN = b.getISBN();
					String oldPrice = b.getPrice();
		            String oldQuantity = b.getQuantity();
					book oldUser = new book(oldName,oldISBN,oldPrice,oldQuantity);
					
					//updating new info
					b.setQuantity(avablquantity);
					
					
					//olso updating in file
					bs.updateUser(oldUser, b);
			
			
			
			JOptionPane.showMessageDialog(this,"Thank You For Purchasing");
			 customerHome sb=new customerHome(u,us,bs,as);
			 sb.setVisible(true);
			 this.setVisible(false);
			}else{
				JOptionPane.showMessageDialog(this,"Informession Missing");
			}
		}else if(ae.getSource()==backButton){
			
			selectPaymentMethod s=new selectPaymentMethod(img,price,quantt,totalQuantity,q,bs,b,totalAmount,u,us,as);
			s.setVisible(true);
			this.setVisible(false);
		}
		
	}
	
	
}