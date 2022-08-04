package modelo;

public class BdData {
    
    private final String driver = "com.mysql.jdbc.Driver";
    private final String user = "root";
    private final String password = "";
    private final String url = "jdbc:mysql://localhost:3306/prestamobiciclestas";

    public String getDriver() {
        return driver;
    }
    public String getUser() {
        return user;
    }
    public String getPassword() {
        return password;
    }
    public String getUrl() {
        return url;
    }
}
