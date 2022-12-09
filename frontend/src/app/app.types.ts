export type Category = {
  id?: number;
  name: string;
  moneySpent: number;
  spentPerMonth: number;
};

export type Spending = {
  id?: number,
  name: string,
  price: number,
  time: number,
  categoryId: number,
  category?: Category
}

