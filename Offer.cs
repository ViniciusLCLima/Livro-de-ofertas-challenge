namespace com.offer{
    public class Offer{
        int qty;
        float value;

        public Offer(float value, int qty){
            this.value = value;
            this.qty = qty;
        }

        public void modify(float value, int qty){
            this.value = value;
            this.qty = qty;
        }

        public String toString(){
            return value + "," + qty;
        }
    }
}