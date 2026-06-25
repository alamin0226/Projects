package Frame;
import Class.*;
import java.lang.*;
import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class intro extends JFrame implements MouseListener,ActionListener{
	JPanel panel;
	JButton button;
	JLabel heading,heading1,bg1;
	users us;
	books bs;
	admins as;
	public intro(users us,books bs,admins as){
		super("Get started");
		this.setSize(800,500);
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		this.setLocationRelativeTo(null);
		this.setResizable(false);
		this.us=us;
		this.bs=bs;
		this.as=as;

        panel=new JPanel();
        panel.setLayout(null);
		
		Font f=new Font("Arial",Font.BOLD,20);//plain
		Font f1=new Font("Arial",Font.PLAIN,15);
		ImageIcon bg=new ImageIcon("Image/bg.jpg");
		Image i1=bg.getImage().getScaledInstance(800,500,Image.SCALE_SMOOTH);
		ImageIcon i2=new ImageIcon(i1);
		
		heading=new JLabel("          TODAY A READER");
		heading.setBounds(250,50,300,30);
		heading.setFont(f);
		heading.setForeground(Color.WHITE);
		panel.add(heading);
		
		heading1=new JLabel("    TOMORROW IS A LEADER");
		heading1.setBounds(250,90,300,30);
		heading1.setFont(f);
		heading1.setForeground(Color.WHITE);
		panel.add(heading1);
		
		button=new JButton("Get started");
		button.setBounds(350,190,110,30);
		button.setBackground(new Color(133,70,255));
		button.addMouseListener(this);
		button.addActionListener(this);
		button.setFont(f1);
		panel.add(button);
		
		bg1=new JLabel(i2);
		bg1.setSize(800,500);
		panel.add(bg1);
		
		this.add(panel);
		//bg1.add(panel);
	}
	
	public void mouseClicked(MouseEvent me){}
	public void mousePressed(MouseEvent me){}
	public void mouseReleased(MouseEvent me){}

	public void mouseEntered(MouseEvent me){
		if(me.getSource()==button){
			button.setBackground(new Color(223,80,242));
			button.setForeground(Color.BLACK);
		}	
	}
	public void mouseExited(MouseEvent me){
		if(me.getSource()==button){
			button.setBackground(new Color(133,70,255));
			button.setForeground(Color.BLACK);
		}
	}
	public void actionPerformed(ActionEvent ae){
		if(ae.getSource()==button){
			dispose();
			intro2 in = new intro2 (us,bs,as);
			in.setVisible(true);
		}
	}
}