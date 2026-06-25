package Frame;
import Class.*;
import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.io.*;
public class buy extends JFrame implements ActionListener{
	private double amount,totalAmount;
	private String price,img,quantt;
	private int totalQuantity,q;
	JLabel imgLabel,numberLabel,priceLabel,quantityLabel;
	JPanel panel;
	JComboBox quantitybox;
	JTextField numberField,pinField,priceField;
	JButton backButton,buyButton;
	book b;
	 books bs;
	 users us;
	 user u;
	 admins as;
	 
				//String(img+price+quantity)Books obj
	 public buy(String img,String price,String quantt,books bs,book b,user u,users us,admins as){
		 this.u=u;
		this.us=us;
		this.bs=bs;
		this.b=b;
		this.as=as;
		this.img=img;
		this.quantt=quantt;
		this.price=price;
		this.setTitle("BookShop");
		this.setSize(800,500);
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		this.setLocationRelativeTo(null);
		
		
		
		Font f=new Font("Arial",Font.BOLD,20);
		
				
		try{
			totalQuantity = Integer.valueOf(quantt); 
				
			}catch(Exception ex){}
		
		
		//amount = Double.valueOf(str);
		try{
		amount = Double.valueOf(price);
		}catch(Exception ex){}
		
		
		ImageIcon image=new ImageIcon(img);
		
		panel=new JPanel();
		panel.setLayout(null);
		
		
		imgLabel=new JLabel(image);
		imgLabel.setBounds(50,100,image.getIconWidth(),image.getIconHeight());
		panel.add(imgLabel);
		
		numberLabel = new JLabel("Price:"+price);
		numberLabel.setBounds(50,300,150,30);
		numberLabel.setFont(f);
		panel.add(numberLabel);
		
		
		quantityLabel=new JLabel("Quantiy");
		quantityLabel.setBounds(380,100,60,25);
		panel.add(quantityLabel);
		
		
		String quantitys[]= {"1","2","3","4","5","6","7","8","9","10"};
		quantitybox = new JComboBox(quantitys);
		quantitybox.setBounds(450,100,60,25);
		panel.add(quantitybox);
		
		
		
		numberLabel = new JLabel("Price:"+price);
		numberLabel.setBounds(50,300,150,30);
		numberLabel.setFont(f);
		panel.add(numberLabel);
	
	    buyButton=new JButton("Buy");
		buyButton.setBounds(380,250,150,30);
		buyButton.addActionListener(this);
		panel.add(buyButton);
		 
		 
		backButton=new JButton("Back");
		backButton.setBounds(380,320,80,30);
		backButton.addActionListener(this);
		panel.add(backButton);
		
		
		
		
		add(panel);
		
		
		
	
    }
	
	public void actionPerformed(ActionEvent ae){
		
		if(ae.getSource()==buyButton){
			
			String qnti = quantitybox.getSelectedItem().toString();
			if(!qnti.isEmpty()){
				
				try{
				q = Integer.valueOf(qnti);
				
			}catch(Exception ex){}
			if ((totalQuantity>=q)&&(totalQuantity!=0)){
			
			totalAmount=q*amount; //quantity*price
			
			
			selectPaymentMethod sp=new selectPaymentMethod(img,price,quantt,totalQuantity,q,bs,b,totalAmount,u,us,as);
			sp.setVisible(true);
			this.setVisible(false);}else{
				JOptionPane.showMessageDialog(this,"Insufficient Quantity");
			}
			}
			
		}else if(ae.getSource()==backButton){
			selectbook sl= new selectbook(bs,u,us,as);
			sl.setVisible(true);
			this.setVisible(false);
		}
		
	}
	
	
}