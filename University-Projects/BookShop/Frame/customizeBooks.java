package Frame;
import Class.*;
import java.lang.*;
import java.awt.*;
import javax.swing.*;
import java.awt.event.*;

public class customizeBooks extends JFrame implements MouseListener,ActionListener
{
    JPanel panel;
    JLabel customerName,customerPassword,conformPassword,bg1,heading,heading2;
    JTextField nameField;
    JPasswordField passwordField,conformPasswordField;
	JButton backButton,saveButton,addBooksButton;
	
	users us;
	books bs;
	admin a;
	admins as;
    public customizeBooks(users us,books bs,admin a,admins as){
        super("Add books or change price or quantity or delete...");
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
		
		//Color ccl = new Color(195,215,235);
		Font f=new Font("Arial",Font.BOLD,20);
		Font f1=new Font("Arial",Font.BOLD,15);
		Font f2=new Font("Arial",Font.PLAIN,17);
		
		heading=new JLabel("If you want to regulate price,quantity or delete books then,");
        heading.setBounds(60,40,600,50);
		heading.setFont(f);
        //heading.setOpaque(true);
        panel.add(heading);
		
		heading2=new JLabel("Want to add books? then,");
        heading2.setBounds(100,300,260,50);
		heading2.setFont(f);
        //heading2.setOpaque(true);
        panel.add(heading2);
		
		addBooksButton=new JButton("Add Books");
		addBooksButton.setBounds(360,305,120,30);//575,345,100,30
		addBooksButton.setBackground(new Color(253,253,253));
		addBooksButton.addMouseListener(this);
		addBooksButton.addActionListener(this);
		addBooksButton.setBorder(null);
		panel.add(addBooksButton);


        customerName=new JLabel("Search books by ISBN :");
        customerName.setBounds(155,97,200,50);
		customerName.setFont(f1);
        //customerName.setOpaque(true);
        panel.add(customerName);

        nameField=new JTextField();
        nameField.setBounds(360,108,150,25);
		nameField.setFont(f2);
		nameField.setBorder(null);
		nameField.setBackground(new Color(253,253,253));
        panel.add(nameField);
		
		saveButton=new JButton("Search");
		saveButton.setBounds(240,177,100,30);//575,345,100,30
		saveButton.setBackground(new Color(253,253,253));
		saveButton.addMouseListener(this);
		saveButton.addActionListener(this);
		saveButton.setBorder(null);
		panel.add(saveButton);
		
		backButton=new JButton("Back");
		backButton.setBounds(400,177,100,30);
		backButton.setBackground(new Color(253,253,253));
		backButton.addMouseListener(this);
		backButton.addActionListener(this);
		backButton.setBorder(null);
		panel.add(backButton);
		
		
		ImageIcon bg=new ImageIcon("Image/forgotPass.jpg");
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
		if(me.getSource()==saveButton){
			saveButton.setBackground(new Color(223,80,242));
			saveButton.setForeground(Color.BLACK);
		}
		if(me.getSource()==backButton){
			backButton.setBackground(new Color(223,80,242));
			backButton.setForeground(Color.BLACK);
		}
		if(me.getSource()==addBooksButton){
			addBooksButton.setBackground(new Color(223,80,242));
			addBooksButton.setForeground(Color.BLACK);
		}
	}
	public void mouseExited(MouseEvent me){
		if(me.getSource()== saveButton){
			saveButton.setBackground(new Color(253,253,253));
			saveButton.setForeground(Color.BLACK);
		}
		if(me.getSource()== backButton){
			backButton.setBackground(new Color(253,253,253));
			backButton.setForeground(Color.BLACK);
		}
		if(me.getSource()== addBooksButton){
			addBooksButton.setBackground(new Color(253,253,253));
			addBooksButton.setForeground(Color.BLACK);
		}
	}
	public void actionPerformed(ActionEvent ae){
		String command = ae.getActionCommand();
		if(saveButton.getText().equals(command)){
			String ISBN = nameField.getText();
			int index = bs.userExists(ISBN);
			if(index == -1){
				JOptionPane.showMessageDialog(this, "Book doesn't exist!");
			}else{
					book b = bs.getUser(index);
					customezeBooksPQD db = new customezeBooksPQD(us,bs,a,as,b);
					db.setVisible(true);
					this.setVisible(false);
					
			}
		}
		if(ae.getSource()==backButton){
			dispose();
			adminHome cHm = new adminHome (us,bs,a,as);
			cHm.setVisible(true);
		}
		if(ae.getSource()==addBooksButton){
			dispose();
			addBooks cHm = new addBooks (us,bs,a,as);
			cHm.setVisible(true);
		}
	}
}
