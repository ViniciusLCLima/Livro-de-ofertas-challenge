using com.offer;

namespace com.offer.book{
    public class OfferBook {
            List<Offer> offers;
            int size;

        public OfferBook(){
            offers = new List<Offer>();
            size = 0;
        }

        public void update(string msg){
            string[] splittedMsg = msg.Split(",");
            int pos = Int32.Parse(splittedMsg[1]);
            switch(splittedMsg[0]){
                case "0":
                    this.insert(pos, float.Parse(splittedMsg[2]), Int32.Parse(splittedMsg[3]));
                    break;
                case "1":
                    this.modify(pos, float.Parse(splittedMsg[2]), Int32.Parse(splittedMsg[3]));
                    break;
                case "2":
                    this.delete(pos);
                    break;
            }
        }

        public void insert(int pos, float val, int qty){
            int newSize = size + 1;
            Offer newOffer = new Offer(val, qty);
            offers.Add(pos == size ? newOffer : null);
            for(int i = newSize; i>pos; i--){
                offers[i] = offers[i-1];
            }
            offers[pos] = newOffer;
            size = newSize;
        }

        public void modify(int pos, float val, int qty){
            offers[pos].modify(val, qty);
        }

        public void delete(int pos){    
            int newSize = size - 1; 
            for(int i = pos; i<newSize; i++){   // *Poderia ser feito apenas com o método RemoveAt da classe List.
                offers[i] = offers[i+1];         // *Could have been done only with the RemoveAt method of List class
            }
            offers.RemoveAt(size);
            size = newSize;
        }

        public string toString(){
            string str = "";
            foreach (Offer offer in offers){
                str += offer.toString() +"\n";
            }

            return str + "\\";
        }
    }
}