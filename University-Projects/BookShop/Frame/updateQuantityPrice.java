package Frame;
import Class.*;
import java.lang.*;
import java.awt.*;
import javax.swing.*;
import java.awt.event.*;

public class updateQuantityPrice extends JFrame implements ActionListener{
	JPanel panel;
	JLabel userLabel, passwordLabel, confirmPassLabel;
	JTextField priceTF,QuantityTF;
	JButton searchBtn,cancelBtn,updateBtn;
	Color myColor1, myColor2, myColor3;
	Font myFont, myFont2;
	ImageIcon icon;
	
	book u;
	users bks;
	books us;
	admin a;
	admins as;
	
	public updateQuantityPrice(book u,users bks,books us,admin a,admins as){
		super("Update Quantity Password");
		this.setSize(800,500);
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		this.setLocationRelativeTo(null);
		
		
		this.u=u;
		this.us=us;
		this.bks=bks;
		this.a=a;
		this.as=as;
		
		myColor1 = new Color(191,232,247);
		myColor2 = new Color(236,235,232);
		myColor3 = new Color(50,120,0);
		myFont = new Font("Century",Font.ITALIC, 17);
		myFont2 = new Font("Times New Roman",Font.PLAIN, 17);
		
		panel = new JPanel();
		panel.setLayout(null);
		panel.setBackground(myColor2);
		
		userLabel = new JLabel("User name: "+ u.getName()); 
		userLabel.setBounds(50,100,350,30);
		userLabel.setFont(myFont2);
		panel.add(userLabel);
		
		passwordLabel = new JLabel("New Price: ");
		passwordLabel.setBounds(50,150,150,30);
		passwordLabel.setFont(myFont2);
		panel.add(passwordLabel);
		
		priceTF = new JPasswordField();
		priceTF.setBounds(200,150,200,30);
		priceTF.setFont(myFont2);
		panel.add(priceTF);
		
		confirmPassLabel = new JLabel("New Quantity: ");
		confirmPassLabel.setBounds(50,190,150,30);
		confirmPassLabel.setFont(myFont2);
		panel.add(confirmPassLabel);
		
		QuantityTF = new JPasswordField();
		QuantityTF.setBounds(200,190,200,30);
		QuantityTF.setFont(myFont2);
		panel.add(QuantityTF);
		
		updateBtn = new JButton("Update");
		updateBtn.setBounds(250,230,90,30);
		updateBtn.setFont(myFont);
		updateBtn.setBackground(myColor1);
		updateBtn.setForeground(myColor3);
		updateBtn.addActionListener(this);
		updateBtn.setBorder(null);
		panel.add(updateBtn);
		
		cancelBtn = new JButton("Cancel");
		cancelBtn.setBounds(150,230,90,30);
		cancelBtn.setFont(myFont);
		cancelBtn.setBackground(myColor1);
		cancelBtn.setForeground(Color.RED);
		cancelBtn.addActionListener(this);
		cancelBtn.setBorder(null);
		panel.add(cancelBtn);
		
		this.add(panel);
		//this.setVisible(true);
	}
	

	public void actionPerformed(ActionEvent ae){
		String command = ae.getActionCommand();
		if(updateBtn.getText().equals(command)){
			String price = priceTF.getText();
			String quantity = QuantityTF.getText();
			if(!price.isEmpty() && !quantity.isEmpty()){
					String oldName = u.getName();
					String oldISBN = u.getISBN();
					String oldPrice = u.getPrice();
		            String oldQuantity = u.getQuantity();
					book oldUser = new book(oldName,oldISBN,oldPrice,oldQuantity);
					
					//updating password in object
					u.setPrice(price);
					u.setQuantity(quantity);
					
					//olso updating in file
					us.updateUser(oldUser, u);
					search c =new search(u,bks,us,a,as);
					c.setVisible(true);
					this.setVisible(false);
					
					JOptionPane.showMessageDialog(this, "Price and Quantity Updated");
		
			}else{
				JOptionPane.showMessageDialog(this, "All field is required");
			}
			
		}else if(cancelBtn.getText().equals(command)){
			search c =new search(us,bks,a,as);
			c.setVisible(true);
			this.setVisible(false);
		}else{}
	}
}