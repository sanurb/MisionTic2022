package controlador;
import modelo.Usuario;
import java.sql.*;
import javax.swing.JComboBox;
import modelo.BdData;

public class UsuarioDAO extends BdData{

    public void consultarEstacion(JComboBox usuario){

        try (Connection conn = DriverManager.getConnection(getUrl(), getUser(), getPassword())) {
            
            String sql = "SELECT id, nombre, apellido FROM bd_usuario";
            Statement stmt = conn.createStatement();
            ResultSet resul = stmt.executeQuery(sql);
            
            while(resul.next()){
                usuario.addItem(resul.getString(1) + "-"  + resul.getString(2) + " " + resul.getString(3) );
            }
           
        } catch (Exception e) {
            System.out.println("Error: " + e.getMessage());
        }
        
    }
    
    public Usuario consultaUsuarioCedula(int cedula){
        Usuario usuario = null;
        
        try (Connection conn = DriverManager.getConnection(getUrl(), getUser(), getPassword())) {
            
            String sql = "SELECT `id`, `nombre`, `apellido`, `cedula` \n" +
                         "FROM `bd_usuario` \n" +
                         "WHERE cedula = ?";
            
            PreparedStatement stmt = conn.prepareStatement(sql);
            stmt.setInt(1, cedula);
            
            ResultSet resul = stmt.executeQuery();
            
            while(resul.next()){
                
                int idUsuario = resul.getInt(1);
                String nombre = resul.getString(2);
                String apellido = resul.getString(3);
                int cedulaUsuario = resul.getInt(4);
                
                usuario = new Usuario(idUsuario, nombre, apellido, cedulaUsuario);
            }
            
            stmt.close();
            resul.close();
            
            return usuario;
            
        } catch (Exception e) {
            System.out.println("Error: " + e.getMessage());            
        }
        
        return usuario;        
    }
    
    public Usuario addUsuario(String nombre, String apellido, int cedula){
         
        Usuario usuario = consultaUsuarioCedula(cedula);
               
        if(usuario == null){
            try (Connection conn = DriverManager.getConnection(getUrl(), getUser(), getPassword())) {

                String sql = "INSERT INTO `bd_usuario`(`nombre`, `apellido`, `cedula`) \n" +
                             "VALUES (?,?,?)";

                PreparedStatement stmt = conn.prepareStatement(sql);
                stmt.setString(1, nombre);
                stmt.setString(2, apellido);
                stmt.setInt(3, cedula);

                stmt.executeUpdate();

                stmt.close();

                return usuario;

            } catch (Exception e) {
                System.out.println("Error: " + e.getMessage());            
            }
        }else{
            return usuario; 
        }
        
        return usuario;
    } 

 }
