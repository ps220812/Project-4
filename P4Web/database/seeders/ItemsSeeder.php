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
            ['id' => 1, 'quantity' => '100', 'unit' => '1', 'ingredient' => '3', 'value' => 80],
            ['id' => 2, 'quantity' => '10', 'unit' => '2', 'ingredient' => '2', 'value' => 40],
        ];

        foreach ($units as $unit) {
            items::create($unit);
        }
        //
    }
}
