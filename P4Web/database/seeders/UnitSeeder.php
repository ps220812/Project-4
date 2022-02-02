<?php

namespace Database\Seeders;

use App\Models\units;
use Illuminate\Database\Seeder;

class UnitSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        $units = [
            ['id' => 1, 'unit_name' => 'stuks'],
            ['id' => 2, 'unit_name' => 'gram'],
        ];

        foreach ($units as $unit) {
            units::create($unit);
        }
        //
    }
}
