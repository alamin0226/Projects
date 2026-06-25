package Frame;
import Class.*;
import java.lang.*;
import java.awt.*;
import javax.swing.*;
import java.awt.event.*;
public class search extends JFrame implements MouseListener,ActionListener{
	JPanel panel;
    JLabel bg1,ISBN,bookName,price,quantity;
	JButton updateButton,backButton;
	ButtonGroup bg;
	book u;
	users us;
	books bks;
	admin a;
	admins as;

    public search(book u,users us,books bks,admin a,admins as){
		this.setTitle("Change price or quantity");
		this.setSize(800,500);
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		this.setLocationRelativeTo(null);
		this.setResizable(false);
		this.u=u;
		this.us=us;
		this.bks=bks;
		this.a=a;
		this.as=as;
		

        panel=new JPanel();
        panel.setLayout(null);
		panel.setBackground(new Color(176,36,160));
		
		Color ccl = new Color(195,215,235);
		Font f1=new Font("Arial",Font.BOLD,15);
		Font f2=new Font("Arial",Font.PLAIN,17);

        ISBN=new JLabel("ISBN :"+u.getISBN());
        ISBN.setBounds(295,50,100,20);
        //ISBN.setOpaque(true);
		ISBN.setFont(f1);
        panel.add(ISBN);
        
        bookName=new JLabel("Book's name :"+u.getName());
        bookName.setBounds(295,90,200,20);
		bookName.setFont(f1);
        //bookName.setOpaque(true);
        panel.add(bookName);
		
		price=new JLabel("Price  :    "+u.getPrice());
		price.setBounds(295,130,200,20);
		price.setFont(f1);
		panel.add(price);
		
		quantity=new JLabel("Quantity  :"+u.getQuantity());
		quantity.setBounds(295,170,200,20);
		quantity.setFont(f1);
		panel.add(quantity);
		
       
		
		updateButton=new JButton("Update");
		updateButton.setBounds(480,300,100,40);
		updateButton.setBackground(new Color(193,255,200));
		updateButton.setBorder(null);
		updateButton.addMouseListener(this);
		updateButton.addActionListener(this);
		panel.add(updateButton);
		
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
	
	public search(books us2, users bks2, admin a2, admins as2) {
        //TODO Auto-generated constructor stub
    }

    public void mouseClicked(MouseEvent me){}
	public void mousePressed(MouseEvent me){}
	public void mouseReleased(MouseEvent me){}
	
	public void mouseEntered(MouseEvent me){
		if(me.getSource()==updateButton){
			updateButton.setBackground(new Color(120,240,119));
			updateButton.setForeground(Color.BLACK);
		}	
		if(me.getSource()==backButton){
			backButton.setBackground(new Color(120,240,119));
			backButton.setForeground(Color.BLACK);
		}	

	}
	public void mouseExited(MouseEvent me){
		if(me.getSource()==updateButton){
			updateButton.setBackground(new Color(193,255,200));
			updateButton.setForeground(Color.BLACK);
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
			Asearch cHm = new Asearch(us,bks,a,as);
			cHm.setVisible(true);
		}
		else if(updateButton.getText().equals(command)){
			
						JOptionPane.showMessageDialog(this,"Are you sure want to update Price and Quantity");
						updateQuantityPrice c = new  updateQuantityPrice(u,us,bks,a,as);
						c.setVisible(true);
						this.setVisible(false);
			}
	}
    
}


