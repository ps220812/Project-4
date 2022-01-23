<?php

namespace Database\Seeders;

use App\Models\Ingredients;
use Illuminate\Database\Seeder;

class ingredientSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        $ingredients = [
            ['id' => 1, 'ingredient' => 'Pepperoni'],
            ['id' => 2, 'ingredient' => 'Salami'],
            ['id' => 3, 'ingredient' => 'Dough'],
            ['id' => 4, 'ingredient' => 'Mozzarella'],
            ['id' => 5, 'ingredient' => 'Gouda'],
            ['id' => 6, 'ingredient' => 'Cheddar'],
        ];
        //
        foreach ($ingredients as $role) {
            ingredients::create($role);
        }
        //
    }
}
