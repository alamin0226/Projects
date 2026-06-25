package Frame;
import Class.*;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;

public class Detective extends JFrame implements ActionListener, MouseListener {
    private ImageIcon book1, book2, book3, book4, book5, book6;
    private JButton bookBtn1, bookBtn2, bookBtn3, bookBtn4, bookBtn5, bookBtn6, backButton;
    private JPanel panel;
	users us;
	books bs;
	admin a;
	admins as;
    public Detective(users us,books bs,admin a,admins as) {
		this.bs=bs;
		this.a=a;
		this.as=as;
		this.us=us;
		
		
        initComponents();
    }

    public void initComponents() {
        setTitle("Book show...");
        this.setSize(800, 500);
        this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        this.setLocationRelativeTo(null);
        this.setResizable(false);

        panel = new JPanel();
        panel.setLayout(null);
		panel.setBackground(Color.PINK);

        // Load images with exception handling
        try {
            book1 = new ImageIcon("Image/p1.jpg");
            book2 = new ImageIcon("Image/p2.jpg");
            book3 = new ImageIcon("Image/p3.png");
            book4 = new ImageIcon("Image/p4.jpg");
            book5 = new ImageIcon("Image/p5.png");
            book6 = new ImageIcon("Image/p6.jpg");
        } catch (Exception e) {
            e.printStackTrace();
        }

        // Create buttons and set image icons
        bookBtn1 = new JButton(book1);
        bookBtn1.setBounds(50, 15, 150, 170);
        panel.add(bookBtn1);

        bookBtn2 = new JButton(book2);
        bookBtn2.setBounds(270, 15, 150, 170);
        panel.add(bookBtn2);

        bookBtn3 = new JButton(book3);
        bookBtn3.setBounds(490, 15, 150, 170);
        panel.add(bookBtn3);

        bookBtn4 = new JButton(book4);
        bookBtn4.setBounds(50, 220, 150, 170);
        panel.add(bookBtn4);

        bookBtn5 = new JButton(book5);
        bookBtn5.setBounds(270, 220, 150, 170);
        panel.add(bookBtn5);

        bookBtn6 = new JButton(book6);
        bookBtn6.setBounds(490, 220, 150, 170);
        panel.add(bookBtn6);

        backButton = new JButton("Back");
        backButton.setBounds(680, 15, 100, 30);
        backButton.setBackground(new Color(253, 253, 253));
        backButton.addMouseListener(this);
        backButton.addActionListener(this);
        backButton.setBorder(null);
        panel.add(backButton);

        this.add(panel);
    }

    @Override
    public void mouseEntered(MouseEvent me) {
        if (me.getSource() == backButton) {
            backButton.setBackground(new Color(223, 80, 242));
            backButton.setForeground(Color.BLACK);
        }
    }

    @Override
    public void mouseExited(MouseEvent me) {
        if (me.getSource() == backButton) {
            backButton.setBackground(new Color(253, 253, 253));
            backButton.setForeground(Color.BLACK);
        }
    }

    @Override
    public void mouseClicked(MouseEvent me) {}

    @Override
    public void mousePressed(MouseEvent me) {}

    @Override
    public void mouseReleased(MouseEvent me) {}

    @Override
    public void actionPerformed(ActionEvent ae) {
        if (ae.getSource() == backButton) {
            dispose();
            adminHome cHm = new adminHome(us,bs,a,as);
            cHm.setVisible(true);
        }
    }
}
