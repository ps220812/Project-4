<?php

namespace Database\Seeders;

use App\Models\PizzaNames;
use Illuminate\Database\Seeder;

class pizzaSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        $pizzas = [
            ['id' => 1, 'pizza_name' => 'Salami'],
            ['id' => 2, 'pizza_name' => 'Double Pepperoni'],
            ['id' => 3, 'pizza_name' => 'Hawaii'],
            ['id' => 4, 'pizza_name' => 'Margaritha'],
            ['id' => 5, 'pizza_name' => 'Four Cheese'],
            ['id' => 6, 'pizza_name' => 'Six Cheese'],
        ];
        //
        foreach ($pizzas as $role) {
            pizzaNames::create($role);
        }
    }
}
