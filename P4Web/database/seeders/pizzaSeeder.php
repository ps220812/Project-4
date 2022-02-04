<?php

namespace Database\Seeders;

use App\Models\pizzaDisplay;
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
            ['id' => 1, 'pizza_id' => 2, 'item_id' => 1],
            ['id' => 2, 'pizza_id' => 2, 'item_id' => 2],
            ['id' => 3, 'pizza_id' => 4, 'item_id' => 1],

        ];

        foreach($pizzas as $pizza){
            pizzaDisplay::create($pizza);
        }
        //
    }
}
