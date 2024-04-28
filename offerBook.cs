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
            int pos = Int32.Parse(splittedMsg[0]);
            switch(splittedMsg[1]){
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
            int elemIdx = pos - 1;
            Offer newOffer = new Offer(val, qty);
            if (pos == newSize) {
                offers.Add(newOffer);
            } else {
                offers.Add(offers[size-1]);
                for(int i = newSize - 1; i>elemIdx; i--){
                    offers[i] = offers[i-1];
                }
                offers[pos-1] = newOffer;
            }
            size = newSize;
        }

        public void modify(int pos, float val, int qty){
            int elemIdx = pos-1;
            offers[elemIdx].modify(val, qty);
        }

        public void delete(int pos){    
            int newSize = size - 1; 
            int elemIdx = pos - 1;
            for(int i = elemIdx; i<newSize; i++){   // *Poderia ser feito apenas com o método RemoveAt da classe List.
                offers[i] = offers[i+1];         // *Could have been done only with the RemoveAt method of List class
            }
            offers.RemoveAt(newSize);
            size = newSize;
        }

        public string toString(){
            string str = "";
            int pos = 1;
            foreach (Offer offer in offers){
                str += pos + "," + offer.toString();
                if (pos != size){
                    str+="\n";
                }
                pos++;
            }

            return str + "\\";
        }
    }
}