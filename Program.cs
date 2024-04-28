// See https://aka.ms/new-console-template for more information

using com.offer.book;


int numInputLines = Int32.Parse(Console.ReadLine());
OfferBook offerBook = new OfferBook();
for (int i = 1; i <= numInputLines; i++){
    string line = Console.ReadLine();
    offerBook.update(line);
}

Console.Write(offerBook.toString());