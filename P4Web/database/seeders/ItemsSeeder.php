<?php

namespace Database\Seeders;

use App\Models\items;
use Illuminate\Database\Seeder;

class ItemsSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        $units = [
            ['id' => 1, 'quantity' => 100, 'unit_id' => '2', 'ingredient_id' => '3', 'price' => 80],
            ['id' => 2, 'quantity' => 10, 'unit_id' => '1', 'ingredient_id' => '2', 'price' => 40],
        ];

        foreach ($units as $unit) {
            items::create($unit);
        }
        //
    }
}
