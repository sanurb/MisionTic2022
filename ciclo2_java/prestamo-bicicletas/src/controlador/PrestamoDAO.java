package controlador;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import modelo.BdData;


public class PrestamoDAO extends BdData{
   
    public boolean addPrestamo(int idEstacion, String idBicicleta, int idUsuario){
     
        try (Connection conn = DriverManager.getConnection(getUrl(), getUser(), getPassword())) {
            
            String sql = "INSERT INTO `bd_prestamo`(`id_estacion`, `id_bicicleta`, `id_usuario`) \n" +
                         "VALUES (?,?,?)";
            
                PreparedStatement stmt = conn.prepareStatement(sql);
                stmt.setInt(1, idEstacion);
                stmt.setString(2, idBicicleta);
                stmt.setInt(3, idUsuario);
                
                stmt.executeUpdate();
                
                stmt.close();
                                
                return true;
            
        } catch (Exception e) {
            System.out.println("Error: " + e.getMessage());
        }
        
        return false;
    }
    
}
