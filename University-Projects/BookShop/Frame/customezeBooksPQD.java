package Frame;
import Class.*;
import java.lang.*;
import java.awt.*;
import javax.swing.*;
import java.awt.event.*;
public class customezeBooksPQD extends JFrame implements MouseListener,ActionListener{
	JPanel panel;
    JLabel bg1,ISBN,bookName,price,quantity;
    JTextField isbnField,nameField,priceField,quantityField;
	JButton signinButton,backButton,deleteButton;
	ButtonGroup bg;
	book b;
	users us;
	books bs;
	admin a;
	admins as;

    public customezeBooksPQD(users us,books bs,admin a,admins as,book b){
		super("Change price or quantity or delete..........");
		this.setSize(800,500);
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		this.setLocationRelativeTo(null);
		this.setResizable(false);
		this.b=b;
		this.us=us;
		this.bs=bs;
		this.a=a;
		this.as=as;
		
		//books us=new books();
		//book u = new book();

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
		
        isbnField=new JTextField(b.getISBN());
        isbnField.setBounds(500,50,200,25);
		isbnField.setBackground(new Color(193,255,200));
		isbnField.setFont(f2);
		isbnField.setBorder(null);
        panel.add(isbnField);

		nameField=new JTextField(b.getName());
		nameField.setBounds(500,90,200,25);
		nameField.setFont(f2);
		nameField.setBorder(null);
		nameField.setBackground(new Color(193,255,200));
		panel.add(nameField);
		
		priceField=new JTextField(b.getPrice());
		priceField.setBounds(500,130,200,25);
		priceField.setFont(f2);
		priceField.setBorder(null);
		priceField.setBackground(new Color(193,255,200));
		panel.add(priceField);
		
		quantityField=new JTextField(b.getQuantity());
		quantityField.setBounds(500,170,200,25);
		quantityField.setFont(f2);
		quantityField.setBorder(null);
		quantityField.setBackground(new Color(193,255,200));
		panel.add(quantityField);
		
		signinButton=new JButton("Save");
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
		
		deleteButton=new JButton("Delete");
		deleteButton.setBounds(560,370,100,40);
		deleteButton.setBackground(new Color(193,255,200));
		deleteButton.addMouseListener(this);
		deleteButton.addActionListener(this);
		deleteButton.setBorder(null);
		panel.add(deleteButton);
		
		
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
		if(me.getSource()==deleteButton){
			deleteButton.setBackground(new Color(120,240,119));
			deleteButton.setForeground(Color.BLACK);
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
		if(me.getSource()==deleteButton){
			deleteButton.setBackground(new Color(193,255,200));
			deleteButton.setForeground(Color.BLACK);
		}
	}
	
	public void actionPerformed(ActionEvent ae){
		String command = ae.getActionCommand();
		//String command = ae.getActionCommand();
		if(deleteButton.getText().equals(command)){
			int dialog = JOptionPane.YES_NO_OPTION;
			int result = JOptionPane.showConfirmDialog(this, "Are you sure you want to delete this book?", "Delete book?", dialog);
			
			if(result == 0){
				bs.deleteUser(b.getISBN());
				
				JOptionPane.showMessageDialog(this, "book deleted. Redirecting to login page.");
				
				customizeBooks lg = new customizeBooks(us,bs,a,as);
				lg.setVisible(true);
				this.setVisible(false);
			}else{ 
				//no nothing 
			}
		}
		
		if(ae.getSource()==backButton){
			dispose();
			customizeBooks cHm = new customizeBooks (us,bs,a,as);
			cHm.setVisible(true);
		}
		if(signinButton.getText().equals(command)){
			String name ="",ISBN="",price="",quantity="";
			           
			name = nameField.getText();
			ISBN=isbnField.getText();
			price =priceField.getText();
			quantity=quantityField.getText();
			
			if((!price.isEmpty()) && (!quantity.isEmpty())){
				int dialog = JOptionPane.YES_NO_OPTION;
				int result = JOptionPane.showConfirmDialog(this, "Are you sure you want to update these informations?", "Profile update?", dialog);
				if(result == 0){
					String oldName=b.getName();
					String oldISBN=b.getISBN();
					String oldPrice=b.getPrice();
					String oldQuantity=b.getQuantity();
					book oldUser=new book(oldName,oldISBN,oldPrice,oldQuantity);
					
					//updating new info
					b.setName(name);
					b.setISBN(ISBN);
					b.setPrice(price);
					b.setQuantity(quantity);
					
				    bs.updateUser(oldUser,b);
					
					dialog = JOptionPane.YES_NO_OPTION;
					result = JOptionPane.showConfirmDialog(this, "Information updated. Do you want to stay on this page?", "Stay on this page?", dialog);
					if(result == 0){
						//do nothing
					}else{
						customizeBooks db = new customizeBooks(us,bs,a,as);
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
    }
}


