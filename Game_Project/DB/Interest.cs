namespace DigitalGameStore.DB; 

public class Interest {
    public int ID { get; set; }
    
    public int GameID { get; set; }
    public Game? Game { get; set; }
}