namespace HashTable
{
    internal class Program
    {
        /**************************
         * 해시테이블 (HashTable)
         * 
         * 키 값을 해시함수로 해싱하여 해시테이블의 특정 위치로 직접 액세스하도록 만든 방식
         * 해시 : 임의의 길이를 가진 데이터를 고정된 길이를 가진 데이터로 매핑
         * 키 데이터(숫자, 문자 등등)을 해쉬함수로 해싱(인덱스화)
         * 
         * <목욕탕에 비유 가능>
         * 목욕탕에 가면 내 키번호에 해당하는 칸에 가서 물건을 보관하고,
         * 떠날 때도 키번호에 해당하는 칸에 가서 물건을 찾아온다.
         * 
         * 해시 = 목욕탕 주인이 키를 주는 행위
         * 키 값 = 번호키
         * 인덱스 = 보관함
         * 데이터 = 보관할 물건
         ***************************/

        // 해시함수의 조건
        // 1. 입력에 대한 해시함수의 결과가 항상 동일한 값이어야 한다.

        // <해시함수의 효율>
        // 1. 해시함수 자체가 느린 경우 의미가 없음.

        // List는 숫자로 접근하고 싶을 때, Dictionary는 문자로 접근할 때 사용

        void Dictionary()
        {
            Dictionary <string, Item> dictionary = new Dictionary<string, Item> ();

            // 추가
            dictionary.Add("초기 아이템", new Item("초보자용 검", 10));
            dictionary.Add("초기 방어구", new Item("초보자용 가죽갑옷", 30))   ;
            dictionary.Add("전직 아이템", new Item("푸른결정", 1));

            // 탐색
            Console.WriteLine(dictionary["초기아이템"]);

            // 접근
            dictionary.Remove("전직아이템");

            // 확인
            if (dictionary.ContainsKey ("초기아이템")) 
            {
                Console.WriteLine("딕셔너리에 초기 아이템이 있음");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public class Item
        {
            public string name;
            public int weight;

            public Item(string name, int weight)
            {
                this.name = name;
                this.weight = weight;
            }
        }
    }
}