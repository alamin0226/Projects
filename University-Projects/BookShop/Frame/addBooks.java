package Frame;
import Class.*;
import java.lang.*;
import java.awt.*;
import javax.swing.*;
import java.awt.event.*;
public class addBooks extends JFrame implements MouseListener,ActionListener{
	JPanel panel;
    JLabel bg1,ISBN,bookName,price,quantity;
    JTextField isbnField,nameField,priceField,quantityField;
	JButton signinButton,backButton;
	ButtonGroup bg;
	book b = null;
	users us;
	books bs;
	admin a;
	admins as;

    public addBooks(users us,books bs,admin a,admins as){
		super("Add Books");
		this.setSize(800,500);
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		this.setLocationRelativeTo(null);
		this.setResizable(false);
		this.us=us;
		this.bs=bs;
		this.a=a;
		this.as=as;

        panel=new JPanel();
        panel.setLayout(null);
		panel.setBackground(new Color(176,36,160));
		
		Color ccl = new Color(195,215,235);
		Font f1=new Font("Arial",Font.BOLD,15);
		Font f2=new Font("Arial",Font.PLAIN,17);

        ISBN=new JLabel("ISBN :");
        ISBN.setBounds(295,50,100,20);
        //ISBN.setOpaque(true);
		ISBN.setFont(f1);
        panel.add(ISBN);
        
        bookName=new JLabel("Book's name :");
        bookName.setBounds(295,90,200,20);
		bookName.setFont(f1);
        //bookName.setOpaque(true);
        panel.add(bookName);
		
		price=new JLabel("Set price :");
		price.setBounds(295,130,200,20);
		price.setFont(f1);
		panel.add(price);
		
		quantity=new JLabel("Set quantity :");
		quantity.setBounds(295,170,200,20);
		quantity.setFont(f1);
		panel.add(quantity);
		
        isbnField=new JTextField();
        isbnField.setBounds(500,50,200,25);
		isbnField.setBackground(new Color(193,255,200));
		isbnField.setFont(f2);
		isbnField.setBorder(null);
        panel.add(isbnField);

		nameField=new JTextField();
		nameField.setBounds(500,90,200,25);
		nameField.setFont(f2);
		nameField.setBorder(null);
		nameField.setBackground(new Color(193,255,200));
		panel.add(nameField);
		
		priceField=new JTextField();
		priceField.setBounds(500,130,200,25);
		priceField.setFont(f2);
		priceField.setBorder(null);
		priceField.setBackground(new Color(193,255,200));
		panel.add(priceField);
		
		quantityField=new JTextField();
		quantityField.setBounds(500,170,200,25);
		quantityField.setFont(f2);
		quantityField.setBorder(null);
		quantityField.setBackground(new Color(193,255,200));
		panel.add(quantityField);
		
		signinButton=new JButton("Add");
		signinButton.setBounds(480,300,100,40);
		signinButton.setBackground(new Color(193,255,200));
		signinButton.setBorder(null);
		signinButton.addMouseListener(this);
		signinButton.addActionListener(this);
		panel.add(signinButton);
		
		backButton=new JButton("Back");
		backButton.setBounds(630,300,100,40);
		backButton.setBackground(new Color(193,255,200));
		backButton.setBorder(null);
		backButton.addMouseListener(this);
		backButton.addActionListener(this);
		panel.add(backButton);
		
		
		ImageIcon bg=new ImageIcon("Image/customizeBooks.jpg");
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
			signinButton.setBackground(new Color(120,240,119));
			signinButton.setForeground(Color.BLACK);
		}	
		if(me.getSource()==backButton){
			backButton.setBackground(new Color(120,240,119));
			backButton.setForeground(Color.BLACK);
		}	
	}
	public void mouseExited(MouseEvent me){
		if(me.getSource()==signinButton){
			signinButton.setBackground(new Color(193,255,200));
			signinButton.setForeground(Color.BLACK);
		}
		if(me.getSource()==backButton){
			backButton.setBackground(new Color(193,255,200));
			backButton.setForeground(Color.BLACK);
		}
	}
	
	public void actionPerformed(ActionEvent ae){
		String command = ae.getActionCommand();
		if(ae.getSource()==backButton){
			dispose();
			customizeBooks cHm = new customizeBooks (us,bs,a,as);
			cHm.setVisible(true);
		}
		if(signinButton.getText().equals(command)){
			String name = "", ISBN = "",price = "",quantity="";
			
			name = nameField.getText();
			ISBN = isbnField.getText();
			price = priceField.getText();
			quantity=quantityField.getText();
			if(!name.isEmpty() && !ISBN.isEmpty() && !price.isEmpty() && !quantity.isEmpty()){
				if(price.equals(price)){
					//user create - user class - object create - add user to userList array
					//book u=new book();
					//books us=new books();
					book b = new book(name,ISBN,price,quantity);
					bs.addUser(b);
					
					JOptionPane.showMessageDialog(this, "Add books sucessfully,press Add for add this book");
					customizeBooks lg = new customizeBooks(us,bs,a,as);
					lg.setVisible(true);
					this.setVisible(false);
				}
			}else{
				JOptionPane.showMessageDialog(this, "Information missing");
			}
			
		}
	}
}

